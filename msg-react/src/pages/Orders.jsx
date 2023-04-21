import { Button, Grid, Stack, Box, Chip, Typography } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";
import React, { useState, useEffect } from 'react';
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import { Table, Column, HeaderCell, Cell } from 'rsuite-table';
import 'rsuite-table/dist/css/rsuite-table.css'
import DetailsModal from "../components/DetailsModal";
import { orderDetails } from '../config/modalConfig';
import { apiConfig } from "../config/apiConfig";

const session = JSON.parse(localStorage.getItem("session")) || {};
const headers = { headers: { 'Authorization': `Bearer ${session.token}`}};
const API_URL = apiConfig.url;

export default function Orders() {
    const { t, i18n } = useTranslation();
    const [ data, setData ] = useState([]);
    const [ update, setUpdate ] = useState(true);
    const [ selectedId, setSelectedId ] = useState(0);
    const [ showModal, setShowModal ] = useState(false);
    const [ modalConfig, setModalConfig ] = useState(orderDetails);

    useEffect(() => {
        async function fetchData() {
            let responce = await axios.get(API_URL + "Orders", headers);
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
        setModalConfig(orderDetails); 
    }

    const onDelete = async (id) => {
        if (id !== 0) {
            if (window.confirm(t("onDelete"))) {
                await axios.delete(API_URL + "Orders/" + id, headers)
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
                    <Typography level="h1" my={1}><Trans i18nKey={"oList"} /></Typography>
                    <Grid width={250} display="flex"
                        justifyContent="space-between"
                        alignItems="center">
                        <Button color="primary"
                            onClick={() => setUpdate(true)}
                            size="lg"
                            variant="solid"><Trans i18nKey={"reload"}
                            sx={{mx:4}}/></Button>
                    </Grid>
                </Grid>
                <Table height={500} data={data} wordWrap hover={false}>
                    <Column width={140} sortable fixed>
                        <HeaderCell><Trans i18nKey={"id"} /></HeaderCell>
                        <Cell dataKey="id" />
                    </Column>

                    <Column flexGrow={3} fullText minWidth={200}>
                        <HeaderCell><Trans i18nKey={"pType"} /></HeaderCell>
                        <Cell>
                            {(rowData, rowIndex) => {
                                return (
                                    <Chip 
                                        color={"info"} 
                                        key={rowIndex} 
                                        size="sm" 
                                        variant="soft" 
                                        sx={{mx: 0.5}}>
                                            { rowData.packType.name } | ID: { rowData.packTypeId }
                                    </Chip>
                                )
                            }}
                        </Cell>
                    </Column>

                    <Column width={140} sortable>
                        <HeaderCell><Trans i18nKey={"date"} /></HeaderCell>
                        <Cell dataKey="date" />
                    </Column>

                    <Column width={200} sortable fullText>
                        <HeaderCell><Trans i18nKey={"phone"} /></HeaderCell>
                        <Cell dataKey="phone" />
                    </Column>

                    <Column width={200} sortable fullText>
                        <HeaderCell><Trans i18nKey={"email"} /></HeaderCell>
                        <Cell dataKey="email" />
                    </Column>

                    <Column width={140} sortable>
                        <HeaderCell><Trans i18nKey={"proc"} /></HeaderCell>
                        <Cell>
                            {(rowData, rowIndex) => {
                                return (
                                    <Chip 
                                        color={rowData.processed ? "success" : "danger"} 
                                        key={rowIndex} 
                                        size="sm" 
                                        variant="soft" 
                                        sx={{mx: 0.5}}>
                                            { rowData.processed ? <Trans i18nKey={"yes"}/> : <Trans i18nKey={"no"}/> }
                                    </Chip>
                                )
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