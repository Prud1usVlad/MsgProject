import { Grid, Select, Stack, Typography, Option, Box, List, ListItem, ListItemButton, ListItemDecorator, ListItemContent, Chip } from "@mui/joy"
import GrassIcon from '@mui/icons-material/Grass';
import { green, grey } from '@mui/material/colors';
import Divider from '@mui/material/Divider';
import { useTranslation, Trans } from "react-i18next";
import { Feedback, Gradient, Grass, Home, InsertChart, Inventory, KeyboardArrowDown, SpeakerPhone } from "@mui/icons-material";
import languageConfig, { langConfig } from "../config/langConfig";
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';


export default function Packs() {

    const { t, i18n } = useTranslation();
    const navigate = useNavigate();
    const session = JSON.parse(localStorage.getItem("session"));


    return(

        <Stack p={3}>
            <Typography level="h1" my={3}><Trans i18nKey={"offers"} /></Typography>

            <Divider variant="middle" />

            <Typography level="body" my={3}> <Trans i18nKey={"lorem"} /></Typography>

            <Divider variant="middle" />
        </Stack>





    )
}