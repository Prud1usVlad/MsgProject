import { Button, Grid, Stack, Box, Chip } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";
import React, { useState, useEffect } from 'react';
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import { Table, Column, HeaderCell, Cell } from 'rsuite-table';
import 'rsuite-table/dist/css/rsuite-table.css'
import DetailsModal from "../components/DetailsModal";
import { dataPieceDetails, dataPieceCreate } from '../config/modalConfig';

var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1QgdG9rZW4iLCJqdGkiOiI1ZWU3NTJmNC0xMzFkLTQyYTMtOTQyYi02N2VhYjRjMjU2M2UiLCJpYXQiOiIwNC4wNC4yMDIzIDEwOjQ3OjM4Iiwicm9sZSI6IkFkbWluIiwiZXhwIjoxNjgwNjkxNjU4LCJpc3MiOiJodHRwOi8vMTkyLjE2OC4xLjIzOTo1MTU3LyIsImF1ZCI6Imh0dHA6Ly8xOTIuMTY4LjEuMjM5OjUxNTcvIn0.0CVfsBeaJ3WzTlO9KQ9XBz9fLRuhOfIaT-yfUkH_dgY" 

const headers = { headers: { 'Authorization': `Bearer ${token}`}};
const API_URL = "http://192.168.1.239:5157/api/";

export default function DataPieces() {
    const { t, i18n } = useTranslation();
    const [ data, setData ] = useState([]);
    const [ update, setUpdate ] = useState(true);
    const [ selectedId, setSelectedId ] = useState(0);
    const [ showModal, setShowModal ] = useState(false);
    const [ modalConfig, setModalConfig ] = useState(dataPieceDetails);

    useEffect(() => {
        async function fetchData() {
            let responce = await axios.get(API_URL + "DataPieces", headers);
            console.log(responce);
            setData(responce.data);
            setUpdate(false);
        }

        if (update === true)
            fetchData();
    }, [update]);

    const onDetails = (id) => {
        console.log(id);
        setSelectedId(id); 
        setShowModal(true);
        setModalConfig(dataPieceDetails); 
    }

    const onCreate = (id) => {
        setSelectedId(0);
        setShowModal(true);
        setModalConfig(dataPieceCreate);
    }

    const onDelete = async (id) => {
        if (id !== 0) {
            if (window.confirm(t("onDelete"))) {
                await axios.delete(API_URL + "DataPieces/" + id, headers)
            }
        }

        setUpdate(true);
    }

    return (
        <Grid container sm={12}>

            {/* TODO create object to pass all of the static props */}
            <DetailsModal open={showModal}
                config={modalConfig} 
                selectedId={selectedId}
                headers={headers}
                onClose={() => { setShowModal(false); setUpdate(true) }}
            >

            </DetailsModal>
            <Grid sm={2}></Grid>
            <Grid sm={8}>
                <Grid container display="flex"
                    justifyContent="space-between"
                    alignItems="center">
                    <h1><Trans i18nKey={"dpList"} /></h1>
                    <Grid width={250} display="flex"
                        justifyContent="space-between"
                        alignItems="center">
                        <Button color="primary"
                            onClick={() => setUpdate(true)}
                            size="lg"
                            variant="outlined"><Trans i18nKey={"reload"}
                            sx={{mx:4}}/></Button>
                        <Button color="primary"
                            onClick={onCreate}
                            size="lg"
                            variant="outlined"><Trans i18nKey={"add"}
                            sx={{m:4}}/></Button>
                    </Grid>
                </Grid>
                <Table height={500} data={data} bordered wordWrap hover>
                    <Column width={140} sortable fixed fullText>
                        <HeaderCell><Trans i18nKey={"id"} /></HeaderCell>
                        <Cell dataKey="id" />
                    </Column>

                    <Column width={200} fullText>
                        <HeaderCell><Trans i18nKey={"name"} /></HeaderCell>
                        <Cell dataKey="name" />
                    </Column>

                    <Column width={140} fullText>
                        <HeaderCell><Trans i18nKey={"units"} /></HeaderCell>
                        <Cell dataKey="measureUnit" />
                    </Column>

                    <Column width={350} fullText>
                        <HeaderCell><Trans i18nKey={"labels"} /></HeaderCell>
                        <Cell>
                            {(rowData, rowIndex) => {
                                return rowData.labels.map( label => {
                                    let color = (label === "PlantRequired") ? "success"
                                        : (label === "OptimizingModelRequired") ? "info"
                                        : "neutral"
                                    
                                    return( <Chip color={color} size="sm" variant="soft" sx={{mx: 0.5}}>{label}</Chip> )
                                })
                            }}
                        </Cell>
                    </Column>

                    <Column width={240}>
                        
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
            <Grid sm={2}></Grid>
        </Grid>
    );
}