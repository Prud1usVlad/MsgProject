import { BrowserRouter, Routes, Route, Navigate, useParams, useNavigate } from "react-router-dom";
import { Button, Stack, Typography,  Card, CardContent, CardCover, Grid, Divider, Box, AspectRatio, Chip, FormControl, FormLabel, Input, FormHelperText } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";
import { useState, useEffect } from 'react';
import { apiConfig } from "../config/apiConfig";
import axios from "axios";
import { checkEmail, checkPhone } from "../config/validators";
import * as React from 'react';
import WarningIcon from '@mui/icons-material/Warning';
import Alert from '@mui/joy/Alert';
import { globalError, orderSuccess } from "../config/modalConfig";
import InfoModal from "../components/InfoModal";

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
const defaultPackType = 
    {
      "id": 0,
      "name": "string",
      "description": "string",
      "price": 0,
      "image": "string",
      "devicesInPack": [
        {
          "id": 0,
          "name": "string",
          "description": "string",
          "image": "string",
          "amount": 0
        }
      ]
    }

export default function LeftOrder(props){

    const [ selected, setSelected ] = useState(defaultPackType);
    const [ currencyRate, setCurrencyRate ] = useState(testingCurrencyRate);

    const [ phone, setPhone ] = useState();
    const [ email, setEmail ] = useState();

    const [ phoneError, setPhoneError ] = useState(false);
    const [ emailError, setEmailError ] = useState(false);
    const [ formError, setFormError ] = useState(false);
    const [ showModal, setShowModal ] = useState(false);
    const [ modalConfig, setModalConfig ] = useState(globalError);

    let { packTypeId } = useParams();
    const { t, i18n } = useTranslation();
    const navigate = useNavigate();

    useEffect(() => {
        async function fetchData() {
            // For testing purposes changed to testing data
            let response = await axios.get(API_URL + "PackTypes/" + packTypeId , headers);
        
            console.log(response)
            setSelected(response.data)

            // For testing purposes changed to testing data
            //let responce = await axios.get(apiConfig.currencyRateUrl, currencyRateHeaders);
        
            setCurrencyRate(testingCurrencyRate);
        }

        fetchData();
    }, []);

    const getPrice = (packType) => {
        if (i18n.language === "ua")
            return "₴ " + Math.round(currencyRate.rates.UAH * packType.price);
        else 
            return "$ " + packType.price
    } 

    const postOrder = async () => {
        let phoneErr = !checkPhone(phone);
        let emailErr = !checkEmail(email);

        setEmailError(emailErr);
        setPhoneError(phoneErr);

        if (phoneErr || emailErr) 
            setFormError(true);
        else {
            let data = {
                "packTypeId": packTypeId,
                "email": email,
                "phone": phone,
            };

            try { 
                await axios.post(API_URL + "Orders", data, headers); 
            } catch {
                setModalConfig(globalError);
                setShowModal(true);
                return;
            }

            setModalConfig(orderSuccess);
            setShowModal(true);
            //navigate("/");
        }
    }

    return (
        <Grid container>
            <Grid xs={5.5}>
                <Stack p={3}>
                    <Grid
                        container
                        justifyContent="center"
                        alignItems="center"
                        
                    >
                        <AspectRatio
                            variant="outlined"
                            ratio="4/3"
                            sx={{
                            width: "60%",
                            bgcolor: 'background.level2',
                            borderRadius: 'md',
                            }}
                            
                            >
                            <img
                                src={selected.image}
                                loading="lazy"
                                alt=""
                                
                            />
                        </AspectRatio>
                    </Grid>

                    <Typography level='h4' my={3}>
                        {selected.name}
                    </Typography>

                    <Divider variant="middle"/>

                    <Typography level='body' my={2}>
                        {selected.description}
                    </Typography>

                    <Divider variant="middle" />

                    <Typography level='h6' my={1}>
                        <Trans i18nKey="devices" /> :
                    </Typography>

                    {selected.devicesInPack.map((item, index) => {
                    return (
                    <Card
                        key={index}
                        variant="outlined"
                        orientation="horizontal"
                        sx={{
                            width: 300,
                            gap: 2,
                            my: 1
                        }}
                    >
                        <AspectRatio ratio="1" sx={{ width: 65 }}>
                            <img
                                src={item.image}
                                loading="lazy"
                                alt=""
                            />
                        </AspectRatio>
                        <div>
                            <Typography level="h1" fontSize="lg" id="card-description" mb={0.5}>
                                {item.name}
                            </Typography>
                            <Chip
                                variant="outlined"
                                color="success"
                                size="md"
                                sx={{ pointerEvents: 'none' }}
                            >
                                X{item.amount}
                            </Chip>
                        </div>
                    </Card>
                    )
                    })}

                    <Divider variant="middle" />

                    <Typography level="h4" my={1}>
                        <Trans i18nKey={"tPrice"}/> { getPrice(selected)}
                    </Typography>
                </Stack>
            </Grid>

            <Divider xs={1} variant="middle" orientation="vertical"/>

            <Grid xs={5.5} >
                <Stack p={3}>
                    <InfoModal 
                        open={showModal} 
                        config={modalConfig} 
                        onClose={
                            () => {
                                setShowModal(false);
                                if (modalConfig === orderSuccess)
                                    navigate('/');
                            }
                        }/>

                    <Typography level="h3" m={3}>
                        <Trans i18nKey={"ioData"}/>
                    </Typography>

                    <Divider variant="middle"/>

                    <Typography level="body2" fontSize={"lg"} m={2}>
                        <Trans i18nKey={"orderText1"}/> 
                        <Typography level="body" variant="outlined" color="info">"{ selected.name }"</Typography> 
                        <Trans i18nKey={"orderText2"}/>
                    </Typography>

                    <Divider variant="middle"/>

                    <Box m={2} 
                        borderRadius={15}
                        bgcolor={"background.body"}
                        p={3}>

                        {formError && <Alert
                            sx={{ alignItems: 'flex-start', mb:2 }}
                            startDecorator={React.cloneElement(<WarningIcon />, {
                                sx: { mt: '2px', mx: '4px' },
                                fontSize: 'xl2',
                            })}
                            variant="soft"
                            color={"warning"}

                            >
                            <div>
                                <Typography fontWeight="lg" mt={0.25}>
                                    <Trans i18nKey={"error"}/>
                                </Typography>
                                <Typography fontSize="sm" sx={{ opacity: 0.8 }}>
                                    <Trans i18nKey={"vError"} />
                                </Typography>
                            </div>
                        </Alert>}


                        <FormControl sx={{mb:3}}>
                            <FormLabel><Trans i18nKey={"email"}/></FormLabel>
                            <Input 
                                placeholder={t("email")} 
                                type="email" 
                                error={emailError}
                                value={email}
                                onChange={(e) => {
                                    setEmail(e.target.value);
                                    setEmailError(!checkEmail(email));
                                }} />
                            <FormHelperText><Trans i18nKey={"emailH"}/></FormHelperText>
                        </FormControl>
                        
                        <FormControl sx={{mb:3}}>
                            <FormLabel><Trans i18nKey={"phone"}/></FormLabel>
                            <Input 
                                placeholder={t("phone")} 
                                type="phone" 
                                error={phoneError}
                                value={phone}
                                onChange={(e) => {
                                    setPhone(e.target.value);
                                    setPhoneError(!checkPhone(phone));
                                }} />
                            <FormHelperText><Trans i18nKey={"phoneH"}/></FormHelperText>
                        </FormControl>

                        <Button 
                            variant="outlined" 
                            color="info" 
                            size="lg"
                            onClick={postOrder}>
                            <Trans i18nKey={"leftOrder"}/>
                        </Button>
                    </Box>
                </Stack>
            </Grid>
        </Grid>
    )
}