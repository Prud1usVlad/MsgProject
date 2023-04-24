import { Grid, Select, Stack, Typography, Option, Box, List, ListItem, ListItemButton, ListItemDecorator, ListItemContent, Chip, Card, Button, AspectRatio } from "@mui/joy"
import Divider from '@mui/material/Divider';
import { useTranslation, Trans } from "react-i18next";
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { apiConfig } from "../config/apiConfig";
import axios from "axios";


export default function PackTypeCard(props) {

    const { t, i18n } = useTranslation();
    const navigate = useNavigate();

    const GetPrice = () => {
        if (i18n.language === "ua")
            return "₴ " + Math.round(props.currencyRate.rates.UAH * props.packType.price);
        else 
            return "$ " + props.packType.price
    } 

    return (
        <Card variant="outlined" sx={{ width: 320 }}>
          <Typography level="h2" fontSize="md" sx={{ mb: 0.5 }}>
            { props.packType.name }
          </Typography>
          <AspectRatio minHeight="120px" maxHeight="200px" sx={{ my: 2 }}>
            <img
              src={ props.packType.image}
              alt=""
            />
          </AspectRatio>
          <Box sx={{ display: 'flex' }}>
            <div>
              <Typography level="body3"><Trans i18nKey={"tPrice"}/></Typography>
              <Typography fontSize="lg" fontWeight="lg">
                { GetPrice() }
              </Typography>
            </div>
            <Button
              variant="solid"
              size="sm"
              color="primary"
              aria-label="Explore Bahamas Islands"
              sx={{ ml: 'auto', fontWeight: 600 }}
              onClick={ props.onDetails }
            >
              <Trans i18nKey={"details"}/>
            </Button>
          </Box>
        </Card>
    );
}