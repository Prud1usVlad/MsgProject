import { Grid, Stack, Typography, Card, Button, AspectRatio, Modal, Sheet, ModalClose, Box, ModalOverflow, ModalDialog  } from "@mui/joy"
import Divider from '@mui/material/Divider';
import { useTranslation, Trans } from "react-i18next";
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { apiConfig } from "../config/apiConfig";
import axios from "axios";
import PackTypeCard from "../components/PackTypeCard";
import PackTypeCardLg from "../components/PackTypeCardLg";

const session = JSON.parse(localStorage.getItem("session")) || {};
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
    const [ selected, setSelected ] = useState({});
    const [ showModal, setShowModal ] = useState(false);
    const [ currencyRate, setCurrencyRate ] = useState(testingCurrencyRate);

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

    const onDetails = (packType) => {
        setSelected(packType)
        setShowModal(true)
    }

    const getPrice = (packType) => {
        if (i18n.language === "ua")
            return "₴ " + Math.round(currencyRate.rates.UAH * packType.price);
        else 
            return "$ " + packType.price
    } 

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
                    <Grid m={3} key={item.Id}> 
                        <PackTypeCard packType={item} 
                            currencyRate={currencyRate}
                            onDetails={() => onDetails(item)}
                        /> 
                    </Grid>
                ))}

            </Grid>


            <Modal
                aria-labelledby="modal-title"
                aria-describedby="modal-desc"
                open={showModal}
                onClose={() => setShowModal(false)}
                sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}
                
            >
                <ModalOverflow>
                <ModalDialog
                    aria-labelledby="basic-modal-dialog-title"
                    aria-describedby="basic-modal-dialog-description"
                    sx={{ maxWidth: 1000, minWidth: 400 }}
                >
                    <ModalClose variant="outlined"
                        sx={{
                            top: 'calc(-1/4 * var(--IconButton-size))',
                            right: 'calc(-1/4 * var(--IconButton-size))',
                            boxShadow: '0 2px 12px 0 rgba(0 0 0 / 0.2)',
                            borderRadius: '50%',
                            bgcolor: 'background.body',
                        }}
                    />

                    <PackTypeCardLg 
                        packType={selected} 
                        onOrder={() => navigate(`/Order/${selected.id}`)}
                        getPrice={() => getPrice(selected)}/>
                </ModalDialog>
                </ModalOverflow>
            </Modal>
        </Stack>





    )
}