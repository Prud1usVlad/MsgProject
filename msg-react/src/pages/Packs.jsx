import { Grid, Select, Stack, Typography, Option, Box, List, ListItem, ListItemButton, ListItemDecorator, ListItemContent, Chip, Card, Button, AspectRatio } from "@mui/joy"
import Divider from '@mui/material/Divider';
import { useTranslation, Trans } from "react-i18next";
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { apiConfig } from "../config/apiConfig";
import axios from "axios";
import PackTypeCard from "../components/PackTypeCard";

const session = JSON.parse(localStorage.getItem("session"));
const headers = { headers: { 'Authorization': `Bearer ${session.token}`}};
const currencyRateHeaders = { headers: { "apikey": apiConfig.currencyRateKey}}
const API_URL = apiConfig.url;

const testingCurrencyRate = {
    success: true,
    timestamp: 1681918323,
    base: "USD",
    date: "2023-04-19",
    rates: {
        UAH: 36.94231
    }
}

export default function Packs() {

    const [ data, setData ] = useState([]);
    const [ update, setUpdate ] = useState(true);
    const [ selectedId, setSelectedId ] = useState(0);
    const [ showModal, setShowModal ] = useState(false);
    const [ currencyRate, setCurrencyRate ] = useState({});

    const { t, i18n } = useTranslation();
    const navigate = useNavigate();
    const session = JSON.parse(localStorage.getItem("session"));

    useEffect(() => {
        async function fetchData() {
            // For testing purposes changed to testing data
            //let responce = await axios.get(apiConfig.currencyRateUrl, currencyRateHeaders);
        
            setCurrencyRate(testingCurrencyRate);
        }

        fetchData();
    }, []);

    useEffect(() => {
        async function fetchData() {
            let responce = await axios.get(API_URL + "PackTypes", headers);
            console.log(responce);
            setData(responce.data);
            setUpdate(false);
        }

        if (update === true)
            fetchData();
    }, [update]);

    return(

        <Stack p={3}>
            <Typography level="h1" my={3}><Trans i18nKey={"offers"} /></Typography>

            <Divider variant="middle" />

            <Typography level="body" my={3}> <Trans i18nKey={"lorem"} /></Typography>

            <Divider variant="middle" />

            <Grid container 
                sx={{ flexGrow: 1 }} 
                justifyContent="space-evenly" 
                columns={{ sx: 3}}> 

                { data.map((item) => (
                    <Grid m={3}> 
                        <PackTypeCard packType={item} 
                            currencyRate={currencyRate}/> 
                    </Grid>
                ))}

            </Grid>
        </Stack>





    )
}