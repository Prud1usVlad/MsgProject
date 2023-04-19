import { Button, Grid, Stack, Box, Chip, Typography } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";
import React, { useState, useEffect } from 'react';
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import { Table, Column, HeaderCell, Cell } from 'rsuite-table';
import 'rsuite-table/dist/css/rsuite-table.css'
import DetailsModal from "../components/DetailsModal";
import { substrateDetails, substrateCreate } from '../config/modalConfig';
import { apiConfig } from "../config/apiConfig";

const session = JSON.parse(localStorage.getItem("session"));
const headers = { headers: { 'Authorization': `Bearer ${session.token}`}};
const API_URL = apiConfig.url;

export default function Substrates() {
    const { t, i18n } = useTranslation();
    const [ data, setData ] = useState([]);
    const [ update, setUpdate ] = useState(true);
    const [ selectedId, setSelectedId ] = useState(0);
    const [ showModal, setShowModal ] = useState(false);
    const [ modalConfig, setModalConfig ] = useState(substrateDetails);

    useEffect(() => {
        async function fetchData() {
            let responce = await axios.get(API_URL + "Substrates", headers);
            console.log(responce);
            setData(responce.data);
            setUpdate(false);
        }

        if (update === true)
            fetchData();
    }, [update]);

    const onDetails = (id) => {
        setSelectedId(id); 
        setShowModal(true);
        setModalConfig(substrateDetails); 
    }

    const onCreate = (id) => {
        setSelectedId(0);
        setShowModal(true);
        setModalConfig(substrateCreate);
    }

    const onDelete = async (id) => {
        if (id !== 0) {
            if (window.confirm(t("onDelete"))) {
                await axios.delete(API_URL + "Substrates/" + id, headers)
            }
        }

        setUpdate(true);
    }

    return (
        <Grid container sm={12} p={3}>

            <DetailsModal open={showModal}
                config={modalConfig} 
                selectedId={selectedId}
                headers={headers}
                onClose={() => { setShowModal(false); setUpdate(true) }}
            >

            </DetailsModal>
            <Grid sm={12}>
                <Grid container display="flex"
                    justifyContent="space-between"
                    alignItems="center">
                    <Typography level="h1" my={1} ><Trans i18nKey={"sList"} /></Typography>
                    <Grid width={250} display="flex"
                        justifyContent="space-between"
                        alignItems="center">
                        <Button color="primary"
                            onClick={() => setUpdate(true)}
                            size="lg"
                            variant="solid"><Trans i18nKey={"reload"}
                            sx={{mx:4}}/></Button>
                        <Button color="primary"
                            onClick={onCreate}
                            size="lg"
                            variant="solid"><Trans i18nKey={"add"}
                            sx={{m:4}}/></Button>
                    </Grid>
                </Grid>
                <Table height={500} data={data} hover={false} wordWrap>
                    <Column width={140} sortable fixed>
                        <HeaderCell><Trans i18nKey={"id"} /></HeaderCell>
                        <Cell dataKey="id" />
                    </Column>

                    <Column width={140} sortable>
                        <HeaderCell><Trans i18nKey={"name"} /></HeaderCell>
                        <Cell dataKey="name" />
                    </Column>

                    <Column width={250} sortable fullText>
                        <HeaderCell><Trans i18nKey={"desc"} /></HeaderCell>
                        <Cell dataKey="description" />
                    </Column>

                    <Column width={80} sortable>
                        <HeaderCell><Trans i18nKey={"price"} /></HeaderCell>
                        <Cell dataKey="price" />
                    </Column>

                    <Column width={80} sortable>
                        <HeaderCell><Trans i18nKey={"volume"} /></HeaderCell>
                        <Cell dataKey="volume" />
                    </Column>

                    <Column width={280} fullText>
                        <HeaderCell><Trans i18nKey={"chars"} /></HeaderCell>
                        <Cell>
                            {(rowData, rowIndex) => {
                                return rowData.characteristics.map( char => {
                                    return( <Chip color="info" size="sm" variant="soft" sx={{mx: 0.5}}>{char.name + ": " + char.value}</Chip> )
                                })
                            }}
                        </Cell>
                    </Column>

                    <Column width={280}>
                        
                        <HeaderCell><Trans i18nKey={"actions"} /></HeaderCell>
                        <Cell>
                        {rowData => (
                            <>
                            <Button variant="outlined" 
                                color="info" 
                                sx={{mx: 0.5, my: 0}}
                                onClick={() => onDetails(rowData.id)}>
                                    <Trans i18nKey={"details"} />
                            </Button>
                            <Button variant="outlined" 
                                color="danger" 
                                sx={{mx: 0.5}}
                                onClick={() => onDelete(rowData.id)}>
                                    <Trans i18nKey={"delete"} />
                            </Button>
                            </>
                        )}
                        </Cell>
                    </Column>
                </Table>
            </Grid>
        </Grid>
    );
}