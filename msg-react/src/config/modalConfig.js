import { Button, Grid, Stack, Box, Chip, List, ListItem, Checkbox, Card, AspectRatio, Typography, Autocomplete, Divider, AutocompleteOption, ListItemDecorator, ListItemContent  } from "@mui/joy";
import React, { useState, useEffect } from 'react';
import axios from "axios";
import FormControl from '@mui/joy/FormControl';
import FormLabel from '@mui/joy/FormLabel';
import Input from '@mui/joy/Input';
import { Trans } from 'react-i18next';
import { apiConfig } from "./apiConfig";
import DeviceTypesRedactor from "../components/DeviceTypesRedactor";

const API_URL = apiConfig.url;

export const dataPieceDetails = {
    header:"dmh_dpDetails",
    subheader:"dmsh_dpDetails",
    controllerAddress:API_URL + "DataPieces/",
    submitAction: async (data) => { },
    showSubmit:false,
    dataModel: {
        id:0,
        name:"",
        measureUnit:"",
        labels:[]
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"measureUnit",
            label:"units",
            type:"string",
            disabled:false,
        },
        {
            name:"labels",
            label:"labels",
            type:"custom",
            disabled:false,
            generate: (item) => { 
                return (<Grid>
                    {
                        item.map( label => {
                            let color = (label === "PlantRequired") ? "success"
                                : (label === "OptimizingModelRequired") ? "info"
                                : "neutral"
                            
                            return( <Chip color={color} size="sm" variant="soft" sx={{mx: 0.5}}>{label}</Chip> )
                        })
                    }
                </Grid>)
            }
        },
    ]
}

export const dataPieceCreate = {
    header:"dmh_dpCreate",
    subheader:"dmsh_dpCreate",
    controllerAddress:API_URL + "DataPieces/",
    submitAction: async (data, address, headers) => await axios.post(address, data, headers),
    showSubmit:true,
    dataModel: {
        id:0,
        name:"",
        measureUnit:"",
        labels:[]
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"measureUnit",
            label:"units",
            type:"string",
            disabled:false,
        },
    ]
}

export const substrateDetails = {
    header:"dmh_sDetails",
    subheader:"dmsh_sDetails",
    controllerAddress:API_URL + "Substrates/",
    submitAction: async (data, address, headers) => await axios.put(address, data, headers),
    showSubmit:true,
    dataModel: {
        id:0,
        name:"",
        description: "string",
        photoUrl: "string",
        price: "0",
        volume: "0",
        characteristics: []
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"description",
            label:"desc",
            type:"text",
            disabled:false,
        },
        {
            name:"price",
            label:"price",
            type:"float",
            disabled:false,
        },
        {
            name:"volume",
            label:"volume",
            type:"float",
            disabled:false,
        },
        {
            name:"characteristics",
            label:"chars",
            type:"custom",
            disabled:false,
            generate: (chars, data, setData) => { 
                console.log(chars)
                return chars.map((char, index) => {
                    return (
                    <FormControl key={index}>
                        <FormLabel><Trans i18nKey={char.name} /></FormLabel>
                        <Input value={data.characteristics[index].value} 
                            onChange={e => {
                                let newObj = {};
                                Object.assign(newObj, data);

                                newObj.characteristics[index].value = e.target.value;

                                setData(newObj);
                            }}
                            type="number"
                            slotProps={{
                                input: {
                                  min: 0,
                                  max: 100,
                                  step: 1,
                                },
                              }} />
                    </FormControl>
                    )
                })
            }
        },
    ]
}

export const substrateCreate = {
    header:"dmh_sCreate",
    subheader:"dmsh_sCreate",
    controllerAddress:API_URL + "Substrates/",
    submitAction: async (data, address, headers) => await axios.post(address, data, headers),
    showSubmit:true,
    dataModel: {
        id:0,
        name:"",
        description: "",
        photoUrl: "",
        price: "",
        volume: "",
        characteristics: [
            {
              name: "Acidity",
              dataPieceId: 1,
              value: ""
            },
            {
              name: "Electrical Capacity",
              dataPieceId: 2,
              value: ""
            },
            {
              name: "Moisure Content",
              dataPieceId: 3,
              value: ""
            }
          ]
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"description",
            label:"desc",
            type:"text",
            disabled:false,
        },
        {
            name:"price",
            label:"price",
            type:"float",
            disabled:false,
        },
        {
            name:"volume",
            label:"volume",
            type:"float",
            disabled:false,
        },
        {
            name:"characteristics",
            label:"chars",
            type:"custom",
            disabled:false,
            generate: (chars, data, setData) => { 
                console.log(chars)
                return chars.map((char, index) => {
                    return (
                    <FormControl key={index}>
                        <FormLabel><Trans i18nKey={char.name} /></FormLabel>
                        <Input value={data.characteristics[index].value} 
                            onChange={e => {
                                let newObj = {};
                                Object.assign(newObj, data);

                                newObj.characteristics[index].value = e.target.value;

                                setData(newObj);
                            }} 
                            type="number"
                            slotProps={{
                                input: {
                                  min: 0,
                                  max: 100,
                                  step: 1,
                                },
                              }}/>
                    </FormControl>
                    )
                })
            }
        },
    ]
}

export const plantDetails = {
    header:"dmh_pDetails",
    subheader:"dmsh_pDetails",
    controllerAddress:API_URL + "Plants/",
    submitAction: async (data, address, headers) => await axios.put(address, data, headers),
    showSubmit:true,
    dataModel: {
        id:0,
        name:"",
        description: "string",
        photoUrl: "string",
        characteristics: []
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"description",
            label:"desc",
            type:"text",
            disabled:false,
        },
        {
            name:"characteristics",
            label:"chars",
            type:"custom",
            disabled:false,
            generate: (chars, data, setData) => { 
                console.log(chars)
                return chars.map((char, index) => {
                    return (
                    <FormControl key={index}>
                        <FormLabel><Trans i18nKey={char.name} /></FormLabel>
                        <Input value={data.characteristics[index].value} 
                            onChange={e => {
                                let newObj = {};
                                Object.assign(newObj, data);

                                newObj.characteristics[index].value = e.target.value;

                                setData(newObj);
                            }} 
                            type="number"
                            slotProps={{
                                input: {
                                  min: 0,
                                  max: 100,
                                  step: 1,
                                },
                              }}/>
                    </FormControl>
                    )
                })
            }
        },
    ]
}

export const plantCreate = {
    header:"dmh_pCreate",
    subheader:"dmsh_pCreate",
    controllerAddress:API_URL + "Plants/",
    submitAction: async (data, address, headers) => await axios.post(address, data, headers),
    showSubmit:true,
    dataModel: {
        id:0,
        name:"",
        description: "",
        photoUrl: "",
        price: "",
        volume: "",
        characteristics: [
            {
              name: "Acidity",
              dataPieceId: 1,
              value: ""
            },
            {
              name: "Electrical Capacity",
              dataPieceId: 2,
              value: ""
            },
            {
              name: "Moisure Content",
              dataPieceId: 3,
              value: ""
            }
          ]
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"description",
            label:"desc",
            type:"text",
            disabled:false,
        },
        {
            name:"characteristics",
            label:"chars",
            type:"custom",
            disabled:false,
            generate: (chars, data, setData) => { 
                console.log(chars)
                return chars.map((char, index) => {
                    return (
                    <FormControl key={index}>
                        <FormLabel><Trans i18nKey={char.name} /></FormLabel>
                        <Input value={data.characteristics[index].value} 
                            onChange={e => {
                                let newObj = {};
                                Object.assign(newObj, data);

                                newObj.characteristics[index].value = e.target.value;

                                setData(newObj);
                            }}
                            type="number"
                            slotProps={{
                                input: {
                                  min: 0,
                                  max: 100,
                                  step: 1,
                                },
                              }} />
                    </FormControl>
                    )
                })
            }
        },
    ]
}

export const orderDetails = {
    header:"dmh_oDetails",
    subheader:"dmsh_oDetails",
    controllerAddress:API_URL + "Orders/",
    submitAction: async (data, address, headers) => await axios.post(address + "Confirm/" + data.id, null, headers),
    showSubmit:true,
    dataModel: {
        id:0,
        name:"",
        description: "string",
        photoUrl: "string",
        characteristics: []
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"date",
            label:"date",
            type:"string",
            disabled:true,
        },
        {
            name:"processed",
            label:"proc",
            type:"custom",
            disabled:true,
            generate: (el) => {
                return (
                    <Chip color={ el ? "success" : "danger"}
                        size="md"
                        variant="solid">{ el ? <Trans i18nKey={"yes"}/> : <Trans i18nKey={"no"}/> }</Chip>
                )
            }
        },
        {
            name:"email",
            label:"email",
            type:"string",
            disabled:true,
        },
        {
            name:"phone",
            label:"phone",
            type:"string",
            disabled:true,
        },
        {
            name:"packType",
            label:"chars",
            type:"custom",
            disabled:true,
            generate: (el) => { 
                return (
                    <Card
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
                                src={el.image}
                                loading="lazy"
                                alt=""
                            />
                        </AspectRatio>
                        <div>
                            <Typography level="h5" mb={0.5}>
                                {el.name}
                            </Typography>
                            <Typography level="h6" mb={0.5}>
                                ID: {el.id}
                            </Typography>
                        </div>
                    </Card>
                )
                
            }
        },
    ]
}

export const deviceTypeDetails = {
    header:"dmh_dtDetails",
    subheader:"dmsh_dtDetails",
    controllerAddress:API_URL + "DeviceTypes/",
    submitAction: async (data, address, headers) => await axios.put(address, data, headers),
    showSubmit: true,
    dataModel: {
        id:0,
        name:"",
        description: "",
        image: ""
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"description",
            label:"desc",
            type:"text",
            disabled:false,
        },
        {
            name:"image",
            label:"image",
            type:"image",
            disabled:false,
        },
    ]
}

export const deviceTypeCreate = {
    header:"dmh_dtCreate",
    subheader:"dmsh_dtCreate",
    controllerAddress:API_URL + "DeviceTypes/",
    submitAction: async (data, address, headers) => await axios.post(address, data, headers),
    showSubmit:true,
    dataModel: {
        id:0,
        name:"",
        description: "",
        image: ""
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"description",
            label:"desc",
            type:"text",
            disabled:false,
        },
        {
            name:"image",
            label:"image",
            type:"image",
            disabled:false,
        },
    ]
}

export const packTypeDetails = {
    header:"dmh_ptDetails",
    subheader:"dmsh_ptDetails",
    controllerAddress:API_URL + "PackTypes",
    submitAction: async (data, address, headers) => await axios.put(address, data, headers),
    showSubmit: true,
    dataModel: {
        id:0,
        name:"",
        description: "",
        image: "",
        price: 0,
        devicesInPack: [],
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"description",
            label:"desc",
            type:"text",
            disabled:false,
        },
        {
            name:"price",
            label:"price",
            type:"float",
            disabled:false,
        },
        {
            name:"image",
            label:"image",
            type:"image",
            disabled:false,
        },
        {
            name:"devicesInPack",
            label:"dInP",
            type:"custom",
            disabled:true,
            generate: (devices, data, setData) => { 
                return( <DeviceTypesRedactor 
                    devices={devices}
                    data={data}
                    setData={setData} />)
            }
        },
        
    ]
}

export const packTypeCreate = {
    header:"dmh_ptCreate",
    subheader:"dmsh_ptCreate",
    controllerAddress:API_URL + "PackTypes",
    submitAction: async (data, address, headers) => { 
        console.log(data);
        await axios.post(address, data, headers)

    },
    showSubmit:true,
    dataModel: {
        id:0,
        name:"",
        description: "",
        image: "",
        price: 0,
        devicesInPack: [],
    },
    properties: [
        {
            name:"id",
            label:"id",
            type:"string",
            disabled:true
        },
        {
            name:"name",
            label:"name",
            type:"string",
            disabled:false,
        },
        {
            name:"description",
            label:"desc",
            type:"text",
            disabled:false,
        },
        {
            name:"price",
            label:"price",
            type:"float",
            disabled:false,
        },
        {
            name:"image",
            label:"image",
            type:"image",
            disabled:false,
        },
        {
            name:"devicesInPack",
            label:"dInP",
            type:"custom",
            disabled:true,
            generate: (devices, data, setData) => { 
                return( <DeviceTypesRedactor 
                    devices={devices}
                    data={data}
                    setData={setData} />)
            }
        },
        
    ]
}

export const globalError = {
    variant: "danger",
    header: "error",
    text: "gError"
}

export const orderSuccess = {
    variant: "success",
    header: "success",
    text: "orderSuccess",
}