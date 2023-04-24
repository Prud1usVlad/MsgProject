import { Button, Grid, Stack, Box, Chip, Typography, TabPanel, TabList, Tabs } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";
import React, { useState, useEffect } from 'react';
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import 'rsuite-table/dist/css/rsuite-table.css'
import DetailsModal from "../components/DetailsModal";
import { plantDetails, plantCreate } from '../config/modalConfig';
import { apiConfig } from "../config/apiConfig";
import Tab, { tabClasses } from '@mui/joy/Tab';
import { BarChart, Bar, Cell, XAxis, YAxis, CartesianGrid, Tooltip, Legend, LineChart, Line } from 'recharts';


const session = JSON.parse(localStorage.getItem("session")) || {};
const headers = { headers: { 'Authorization': `Bearer ${session.token}`}};
const API_URL = apiConfig.url;

export default function Statistics() {
    const { t, i18n } = useTranslation();
    const [ update, setUpdate ] = useState(true);
    const [ packsStat, setPacksStat ] = useState([{}]);
    const [ ordersStat, setOrdersStat ] = useState([{}]);
    const [ mqttStat, setMqttStat ] = useState([{}]);
    const [ selectedId, setSelectedId ] = useState(0);

    const [index, setIndex] = useState(0);

    const chartColors = ['#0077be', '#f44336', '#9c27b0', '#ff9800', '#4caf50', '#2196f3', '#673ab7', '#cddc39', '#795548', '#e91e63'];


    useEffect(() => {
        async function fetchData() {
            let packs = await axios.get(API_URL + "Statistics/DevicePack", headers);
            let orders = await axios.get(API_URL + "Statistics/Orders", headers);
            let mqtt = await axios.get(API_URL + "Statistics/MqttPayload", headers);

            setPacksStat(packs.data);
            setOrdersStat(orders.data);
            setMqttStat(mqtt.data);

            setUpdate(false);
            console.log(mqtt.data);
        }

        if (update === true)
            fetchData();
    }, [update]);


    return (
        <Stack p={3}>
            <Typography level="h1" m={3}><Trans i18nKey={"stat"} /></Typography>
            <Box
                sx={{
                    bgcolor: 'background.body',
                    flexGrow: 1,
                    m: 3,
                    overflowX: 'hidden',
                    borderRadius: 'md',
                }}
                >
                <Tabs
                    aria-label="Pipeline"
                    value={index}
                    onChange={(event, value) => setIndex(value)}
                    sx={{ '--Tabs-gap': '0px' }}
                >
                    <TabList
                    variant="plain"
                    sx={{
                        width: '100%',
                        mx: 'auto',
                        pt: 2,
                        alignSelf: 'flex-start',
                        [`& .${tabClasses.root}`]: {
                        bgcolor: 'transparent',
                        boxShadow: 'none',
                        '&:hover': {
                            bgcolor: 'transparent',
                        },
                        [`&.${tabClasses.selected}`]: {
                            color: 'primary.plainColor',
                            fontWeight: 'lg',
                            '&:before': {
                            content: '""',
                            display: 'block',
                            position: 'absolute',
                            zIndex: 1,
                            bottom: '-1px',
                            left: 'var(--ListItem-paddingLeft)',
                            right: 'var(--ListItem-paddingRight)',
                            height: '3px',
                            borderTopLeftRadius: '3px',
                            borderTopRightRadius: '3px',
                            bgcolor: 'primary.500',
                            },
                        },
                        },
                    }}
                    >
                        <Tab>
                            <Trans i18nKey={"dpStat"}/>
                        </Tab>
                        <Tab>
                            <Trans i18nKey={"oStat"}/>
                        </Tab>
                        <Tab>
                            <Trans i18nKey={"mpStat"}/>
                        </Tab>
                    </TabList>
                    <Box
                    sx={(theme) => ({
                        '--bg': theme.vars.palette.background.level3,
                        height: '1px',
                        background: 'var(--bg)',
                        boxShadow: '0 0 0 100vmax var(--bg)',
                        clipPath: 'inset(0 -100vmax)',
                    })}
                    />
                    <Box
                    sx={(theme) => ({
                        '--bg': theme.vars.palette.background.level1,
                        background: 'var(--bg)',
                        boxShadow: '0 0 0 100vmax var(--bg)',
                        clipPath: 'inset(0 -100vmax)',
                        px: 4,
                        py: 2,
                    })}
                    >
                        <TabPanel value={0}>
                            <Stack p={1}
                                justifyContent="center"
                                alignItems="center">
                                
                                <Typography level="h6"><Trans i18nKey={packsStat[0]["Label"]} /></Typography>

                                <BarChart
                                    width={800}
                                    height={450}
                                    data={packsStat}
                                >
                                    <CartesianGrid strokeDasharray="3 3" />
                                    <YAxis padding={{ top: 30, bottom: 30 }}/>
                                    <Legend />
                                    {Object.keys(packsStat[0]).map((item, idx) => {
                                        if (item === "Label")
                                            return null;
                                        else 
                                            return (<Bar dataKey={item} fill={chartColors[idx]} />)
                                    })}
                                </BarChart>
                                    
                            </Stack>
                        </TabPanel>
                        <TabPanel value={1}>
                            <Stack p={1}
                                justifyContent="center"
                                alignItems="center">
                                
                                <Typography level="h6" m={2}><Trans i18nKey={"oByDate"} /></Typography>

                                <LineChart
                                    width={800}
                                    height={450}
                                    data={ordersStat}
                                    >
                                    <CartesianGrid strokeDasharray="3 3" />
                                    <XAxis dataKey="Label" padding={{ left: 30, right: 30}} />
                                    <YAxis padding={{ top: 30, bottom: 30}}/>
                                    <Tooltip />
                                    <Legend />
                                    {Object.keys(ordersStat[0]).map((item, idx) => {
                                        if (item === "Label" || item === "Total Income")
                                            return null;
                                        else 
                                            return (<Line type="monotone" dataKey={item} stroke={chartColors[idx]} />)
                                    })}

                                </LineChart>

                                <Typography level="h6" m={2}><Trans i18nKey={"iByDate"} /></Typography>

                                <LineChart
                                    width={800}
                                    height={450}
                                    data={ordersStat}
                                    >
                                    <CartesianGrid strokeDasharray="3 3" />
                                    <XAxis dataKey="Label" padding={{ left: 30, right: 30}} />
                                    <YAxis padding={{ top: 30, bottom: 30}}/>
                                    <Tooltip />
                                    <Legend />
                                    {Object.keys(ordersStat[0]).map((item, idx) => {
                                        if (item === "Total Income")
                                            return (<Line type="monotone" dataKey={item} stroke={chartColors[idx]} />)
                                    })}

                                </LineChart>
                            </Stack>
                        </TabPanel>
                        <TabPanel value={2}>
                            <Stack p={1}
                                justifyContent="center"
                                alignItems="center">
                                
                                <Typography level="h6" m={2}><Trans i18nKey={"oByDate"} /></Typography>

                                <LineChart
                                    width={800}
                                    height={450}
                                    data={mqttStat}
                                    >
                                    <CartesianGrid strokeDasharray="3 3" />
                                    <XAxis dataKey="Label" padding={{ left: 30, right: 30}} />
                                    <YAxis padding={{ top: 30, bottom: 30}}/>
                                    <Tooltip />
                                    <Legend />
                                    <Line type="monotone" dataKey={"Amount"} stroke={chartColors[1]} />

                                </LineChart>
                            </Stack>
                        </TabPanel>
                    </Box>
                </Tabs>
            </Box>
        </Stack>
    );
}