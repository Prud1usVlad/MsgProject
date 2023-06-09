import { Button, Grid, Stack, Box, Chip, Typography, AspectRatio,  AutocompleteOption, Autocomplete, ListItemDecorator, ListItemContent, Slider } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";
import React, { useState, useEffect } from 'react';
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import { Table, Column, HeaderCell, Cell } from 'rsuite-table';
import 'rsuite-table/dist/css/rsuite-table.css'
import DetailsModal from "../components/DetailsModal";
import { packTypeCreate, packTypeDetails } from '../config/modalConfig';
import { apiConfig } from "../config/apiConfig";

const session = JSON.parse(localStorage.getItem("session")) || {};
const headers = { headers: { 'Authorization': `Bearer ${session.token}`}};
const API_URL = apiConfig.url;

export default function PackTypes() {
    const { t, i18n } = useTranslation();
    const [ autocompleteSelected, setAutocompleteSelected] = useState([]);
    const [ allData, setAllData ] = useState([]);
    const [ data, setData ] = useState([]);
    const [ update, setUpdate ] = useState(true);
    const [ selectedId, setSelectedId ] = useState(0);
    const [ showModal, setShowModal ] = useState(false);
    const [ modalConfig, setModalConfig ] = useState(packTypeDetails);
    const [ priceFilter, setPriceFilter ] = useState([0, 10]);

    const [ maxPrice, setMaxPrice] = useState(10);

    useEffect(() => {
        async function fetchData() {
            let response = await axios.get(API_URL + "PackTypes", headers);
            console.log(response);
            setAllData(response.data);
            setData(response.data);
            setAutocompleteSelected([]);
            setUpdate(false);

            let prices = response.data.map(el => el.price);
            let volumes = response.data.map(el => el.volume);

            setPriceFilter([Math.min(...prices), Math.max(...prices)]);
            setMaxPrice(Math.max(...prices));
        }

        if (update === true)
            fetchData();
    }, [update]);

    useEffect(() => {
        let newData = allData.filter(e => e.price >= priceFilter[0] && e.price <= priceFilter[1]);

        if (autocompleteSelected.length > 0)
            newData = newData.filter(e => autocompleteSelected.find(i => i.id === e.id))

        setData(newData);
        
    }, [priceFilter, autocompleteSelected])

    const onDetails = (id) => {
        setSelectedId(id); 
        setShowModal(true);
        setModalConfig(packTypeDetails); 
    }

    const onCreate = (id) => {
        setSelectedId(0);
        setShowModal(true);
        setModalConfig(packTypeCreate);
    }

    const onDelete = async (id) => {
        if (id !== 0) {
            if (window.confirm(t("onDelete"))) {
                await axios.delete(API_URL + "PackTypes/" + id, headers)
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
                    <Typography level="h1" my={1}><Trans i18nKey={"ptList"} /></Typography>
                    <Grid width={250} display="flex"
                        justifyContent="space-between"
                        alignItems="center">
                        <Button color="primary"
                            onClick={() => setUpdate(true)}
                            size="lg"
                            variant="solid"><Trans i18nKey={"reload"}
                            sx={{mx:4}}/></Button>
                        <Button color="primary"
                            onClick={onCreate}
                            size="lg"
                            variant="solid"><Trans i18nKey={"add"}
                            sx={{m:4}}/></Button>
                    </Grid>
                </Grid>


                <Stack bgcolor={"background.body"}
                    p={2}
                    my={2}
                    borderRadius={10}>
                    <Typography level="h6" my={1}><Trans i18nKey={"tools"} /></Typography>
                    <Box sx={{ width: "40%" }}>
                        <Typography level="body"><Trans i18nKey={"price"} />{` | ${priceFilter[0]}$ - ${priceFilter[1]}$`}</Typography>
                        <Slider
                            getAriaLabel={() => t("price")}
                            value={priceFilter}
                            onChange={(e, v) => {setPriceFilter(v)}}
                            valueLabelDisplay="auto"
                            getAriaValueText={v => (v + "$") }
                            min={0}
                            max={maxPrice}
                            step={1}
                        />
                    </Box>

                    <Autocomplete
                        my={3}
                        placeholder={t("pType")}
                        value={autocompleteSelected}
                        options={allData}
                        sx={{ width: "40%" }}
                        getOptionLabel={(option) => option.name}
                        onChange={(event, newValue) => {
                            setAutocompleteSelected(newValue);
                        }}
                        limitTags={3}
                        multiple
                        renderOption={(props, option) => (
                            <AutocompleteOption {...props}>
                                <ListItemDecorator>
                                    <img
                                        loading="lazy"
                                        width="40"
                                        src={option.image}
                                        alt=""
                                    />
                                </ListItemDecorator>
                                <ListItemContent sx={{ fontSize: 'sm' }}>
                                    <Typography level="body1" mx={2}>
                                        { option.name }
                                    </Typography>
                                    <Typography level="body2" mx={2}>
                                        { "ID: " + option.id }
                                    </Typography>
                                    <Typography level="body2" mx={2}>
                                        { "Price: " + option.price + "$" }
                                    </Typography>
                                </ListItemContent>
                            </AutocompleteOption>
                        )}
                    />
                </Stack>


                <Table height={500} data={data} wordWrap hover={false}>
                    <Column width={140} sortable fixed>
                        <HeaderCell><Trans i18nKey={"id"} /></HeaderCell>
                        <Cell dataKey="id" />
                    </Column>

                    <Column width={140} sortable>
                        <HeaderCell><Trans i18nKey={"name"} /></HeaderCell>
                        <Cell dataKey="name" />
                    </Column>

                    <Column flexGrow={3} minWidth={400} sortable>
                        <HeaderCell><Trans i18nKey={"desc"} /></HeaderCell>
                        <Cell dataKey="description" />
                    </Column>

                    <Column width={80} sortable>
                        <HeaderCell><Trans i18nKey={"image"} /></HeaderCell>
                        <Cell dataKey="description">
                            {rowData => (
                                <AspectRatio
                                    variant="outlined"
                                    ratio="4/3"
                                    sx={{
                                        width: 70,
                                        bgcolor: 'background.level2',
                                        borderRadius: 'md',
                                    }}
                                >
                                    <img
                                        src={rowData.image}
                                        loading="lazy"
                                        alt=""
                                        
                                    />
                                </AspectRatio>
                            )}
                        </Cell>
                    </Column>

                    <Column width={100} sortable>
                        <HeaderCell><Trans i18nKey={"price"} /></HeaderCell>
                        <Cell dataKey="price" />
                    </Column>

                    <Column width={200}>
                        
                        <HeaderCell><Trans i18nKey={"actions"} /></HeaderCell>
                        <Cell>
                        {rowData => (
                            <Stack>
                                {rowData.devicesInPack.map((el, idx) => {
                                    return(
                                        <Chip 
                                            color="info" 
                                            size="sm" 
                                            variant="soft" 
                                            sx={{m:1}}>
                                                {el.name + ": X" + el.amount}
                                        </Chip>            
                                    )
                                })}
                            </Stack>)
                        }
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