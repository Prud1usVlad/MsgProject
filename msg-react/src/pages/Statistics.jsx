import { Button, Grid, Stack, Box, Chip, Typography, TabPanel, TabList, Tabs, RadioGroup, Radio } from "@mui/joy";
import CheckIcon from '@mui/icons-material/Check';
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
    const periods = [ "all", "year", "month", "week"]

    const { t, i18n } = useTranslation();
    const [ update, setUpdate ] = useState(true);

    const [ packsStat, setPacksStat ] = useState([{}]);
    const [ ordersStat, setOrdersStat ] = useState([{}]);
    const [ mqttStat, setMqttStat ] = useState([{}]);

    const [selectedPeriod, setSelectedPeriod] = useState("all");

    const [index, setIndex] = useState(0);

    const chartColors = ['#0077be', '#f44336', '#9c27b0', '#ff9800', '#4caf50', '#2196f3', '#673ab7', '#cddc39', '#795548', '#e91e63'];


    useEffect(() => {
        async function fetchData() {
            let packs = await axios.get(API_URL + "Statistics/DevicePack", headers);
            let orders = await axios.get(API_URL + "Statistics/Orders", headers);
            let mqtt = await axios.get(API_URL + "Statistics/MqttPayload", headers);

            updateByPeriod({
                packs: packs.data,
                orders: orders.data,
                mqtt: mqtt.data
            })

            setUpdate(false);
        }

        if (update === true)
            fetchData();
    }, [update]);

    const updateByPeriod = (data) => {
        let index = periods.indexOf(selectedPeriod);
        console.log('data', data)

        setPacksStat(data.packs);

        if (index === 0) {
            setOrdersStat(data.orders);
            setMqttStat(data.mqtt);
        } else if (index === 1) {
            let pivot = new Date().setFullYear(new Date().getFullYear() - 1)
            setData(data, pivot);
        } else if (index === 2) {
            let pivot = new Date().setMonth(new Date().getMonth() - 1)
            setData(data, pivot);
        } else if (index === 3) {
            let pivot = new Date().setDate(new Date().getDate() - 7)
            setData(data, pivot);            
        }
    }

    const setData = (data, pivot) => {

        const ordersData = data.orders.filter(i => {
            var dateParts = i.Label.split("/");
            var date = new Date(+dateParts[2], dateParts[0] - 1, +dateParts[1]);
            return date > pivot;
        })

        const mqttData = data.mqtt.filter(i => {
            var dateParts = i.Label.split("/");
            var date = new Date(+dateParts[2], dateParts[0] - 1, +dateParts[1]);
            return date > pivot;
        })

        setOrdersStat(ordersData.length > 0 ? ordersData : [{}]);
        setMqttStat(mqttData.length > 0 ? mqttData : [{}]);
    }

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
                    bgcolor={"background.body"}
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
                    bgcolor={"background.body"}
                    sx={(theme) => ({
                        boxShadow: '0 0 0 100vmax var(--bg)',
                        clipPath: 'inset(0 -100vmax)',
                        px: 4,
                        py: 2,
                    })}
                    >
                        <TabPanel value={0} 
                            bgcolor={"background.body"}>
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
                                <Stack
                                    bgcolor={"background.level1"}
                                    p={2}
                                    my={2}
                                    borderRadius={10}>
                                    <Typography level="h6" m={2}><Trans i18nKey={"period"} /></Typography>

                                    <Box>
                                        <RadioGroup
                                            orientation="horizontal"
                                            sx={{ flexWrap: 'wrap', gap: 1 }}
                                        >
                                            {periods.map((period) => {
                                                const checked = selectedPeriod === period;
                                                return (
                                                    <Chip
                                                        key={period}
                                                        variant={checked ? 'soft' : 'plain'}
                                                        color={checked ? 'info' : 'neutral'}
                                                        startDecorator={
                                                            checked && <CheckIcon sx={{ zIndex: 1, pointerEvents: 'none' }} />
                                                        }
                                                    >
                                                        <Radio
                                                            variant="outlined"
                                                            color={checked ? 'info' : 'neutral'}
                                                            disableIcon
                                                            overlay
                                                            label={t(period)}
                                                            value={t(period)}
                                                            checked={checked}
                                                            onChange={(event) => {
                                                                if (event.target.checked) {
                                                                    setSelectedPeriod(period);
                                                                    setUpdate(true);
                                                                }
                                                            }}
                                                        />
                                                    </Chip>
                                                );
                                            })}
                                        </RadioGroup>
                                    </Box>
                                </Stack>
                                
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

                                <Stack
                                    bgcolor={"background.level1"}
                                    p={2}
                                    my={2}
                                    borderRadius={10}>
                                    <Typography level="h6" m={2}><Trans i18nKey={"period"} /></Typography>

                                    <Box>
                                        <RadioGroup
                                            orientation="horizontal"
                                            sx={{ flexWrap: 'wrap', gap: 1 }}
                                        >
                                            {periods.map((period) => {
                                                const checked = selectedPeriod === period;
                                                return (
                                                    <Chip
                                                        key={period}
                                                        variant={checked ? 'soft' : 'plain'}
                                                        color={checked ? 'info' : 'neutral'}
                                                        startDecorator={
                                                            checked && <CheckIcon sx={{ zIndex: 1, pointerEvents: 'none' }} />
                                                        }
                                                    >
                                                        <Radio
                                                            variant="outlined"
                                                            color={checked ? 'info' : 'neutral'}
                                                            disableIcon
                                                            overlay
                                                            label={t(period)}
                                                            value={t(period)}
                                                            checked={checked}
                                                            onChange={(event) => {
                                                                if (event.target.checked) {
                                                                    setSelectedPeriod(period);
                                                                    setUpdate(true);
                                                                }
                                                            }}
                                                        />
                                                    </Chip>
                                                );
                                            })}
                                        </RadioGroup>
                                    </Box>
                                </Stack>
                                
                                <Typography level="h6" m={2}><Trans i18nKey={"mpStat"} /></Typography>

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