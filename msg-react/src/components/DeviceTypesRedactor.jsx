import { Button, Grid, Stack, Box, Chip, List, ListItem, Checkbox, Card, AspectRatio, Typography, Autocomplete, Divider, AutocompleteOption, ListItemDecorator, ListItemContent  } from "@mui/joy";
import React, { useState, useEffect } from 'react';
import axios from "axios";
import FormControl from '@mui/joy/FormControl';
import FormLabel from '@mui/joy/FormLabel';
import Input from '@mui/joy/Input';
import { Trans } from 'react-i18next';
import { apiConfig } from "../config/apiConfig";

const API_URL = apiConfig.url;

export default function DeviceTypesRedactor(props) {
    const [ options, setOptions ] = useState([]);

    useEffect(() => {
        async function fetchData() {
            let responce = await axios.get(API_URL + "DeviceTypes");
            console.log(responce);
            setOptions(responce.data);
        }

        fetchData();
    }, []);

    const updateData = (newDevices) => {
        let newObj = {};
        Object.assign(newObj, props.data);

        newObj.devicesInPack = newDevices;

        props.setData(newObj);
    }

    return (
        <Stack>
            {options.map((item, idx) => {
                return (
                    <Card
                        key={idx}
                        variant="outlined"
                        orientation="horizontal"
                        sx={{
                            width: 400,
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
                            <FormControl>
                                <FormLabel><Trans i18nKey={"amount"} /></FormLabel>
                                <Input  
                                    onChange={e => {
                                        let devices = props.data.devicesInPack;
                                        let element = devices.find(el => el.id === item.id);

                                        if (element && e.target.value === 0) {
                                            const index = devices.indexOf(element);
                                            devices.splice(index, 1);
                                        }
                                        else if (element && e.target.value !== 0) {
                                            element.amount = e.target.value
                                        }
                                        else if (!element && e.target.value !== 0) {
                                            devices.push({
                                                id: item.id, 
                                                amount: e.target.value, 
                                                name: item.name, 
                                                description: 
                                                item.description, 
                                                image: item.image
                                            });
                                        }

                                        updateData(devices);
                                    }}
                                    type="number"
                                    slotProps={{
                                        input: {
                                            min: 0,
                                            step: 1,
                                        },
                                        }} />
                            </FormControl>
                        </div>
                    </Card>
                )
            })}
        </Stack>



    // <FormControl key={index}>
    //     <FormLabel><Trans i18nKey={char.name} /></FormLabel>
    //     <Input value={data.characteristics[index].value} 
    //         onChange={e => {
    //             let newObj = {};
    //             Object.assign(newObj, data);

    //             newObj.characteristics[index].value = e.target.value;

    //             setData(newObj);
    //         }}/>
    // </FormControl>
    )
} 