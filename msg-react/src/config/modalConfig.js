import { Button, Grid, Stack, Box, Chip, List, ListItem, Checkbox } from "@mui/joy";
import React, { useState, useEffect } from 'react';
import axios from "axios";
import FormControl from '@mui/joy/FormControl';
import FormLabel from '@mui/joy/FormLabel';
import Input from '@mui/joy/Input';
import { Trans } from 'react-i18next';

const API_URL = "http://192.168.1.239:5157/api/";

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
            type:"string",
            disabled:false,
        },
        {
            name:"volume",
            label:"volume",
            type:"string",
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
            type:"string",
            disabled:false,
        },
        {
            name:"volume",
            label:"volume",
            type:"string",
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
                            }} />
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
                            }} />
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
                            }} />
                    </FormControl>
                    )
                })
            }
        },
    ]
}