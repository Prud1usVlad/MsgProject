import { Grid, Select, Stack, Typography, Option, Box, List, ListItem, ListItemButton, ListItemDecorator, ListItemContent, Chip } from "@mui/joy"
import GrassIcon from '@mui/icons-material/Grass';
import { green, grey } from '@mui/material/colors';
import Divider from '@mui/material/Divider';
import { useTranslation, Trans } from "react-i18next";
import { Feedback, Gradient, Grass, Home, InsertChart, Inventory, KeyboardArrowDown, ListAlt, Login, Logout, SpeakerPhone } from "@mui/icons-material";
import languageConfig, { langConfig } from "../config/langConfig";
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';


export default function SideMenue(props) {

    const { t, i18n } = useTranslation();
    const [selectedLang, setSelectedLang] = useState(i18n.language);
    const navigate = useNavigate();
    const session = JSON.parse(localStorage.getItem("session")) || {};

    const changeLanguage = (lng) => {
        i18n.changeLanguage(lng);
    };

    console.log(session);

    const logOut = () => {
        localStorage.removeItem("session");
        navigate("/");
    }

    return (
        <Stack sx={{
            height: "100%",
          }}
            bgcolor={"background.body"}
            boxShadow="md">
            <Box onClick={() => navigate("/")}
                sx={{ cursor: "pointer" }}>
                <Typography startDecorator={<GrassIcon sx={{ fontSize: 50 }}/>}
                    level="h3"
                    sx={{ m: 1}}
                    textColor={"text.primary"}
                    >
                    Micro & soft Greens
                </Typography>
            </Box>

            <Divider variant="middle" />

            <Grid container
                p={2}
                justifyContent="space-between"
                alignItems="center">
                <Grid sx={6}>
                    <Typography level="body" 
                    sx={{ m: 1}}
                    textColor={"text.primary"} ><Trans i18nKey={"lang"}/></Typography>
                </Grid>
                <Grid sx={6}>
                    <Select indicator={<KeyboardArrowDown /> } 
                        value={selectedLang}>
                        {langConfig.languages.map((item, index) => 
                            <Option key={index} 
                                value={item.key}
                                onClick={() => {
                                    changeLanguage(item.key);
                                    setSelectedLang(item.key);
                                }}>{item.name}</Option>
                        )}
                    </Select>
                </Grid>
            </Grid>

            <Divider variant="middle" />
            
            <Grid container>
            <List p={2}>
                <ListItem onClick={() => navigate("/")}>
                    <ListItemButton>
                        <ListItemDecorator><Home /></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"home"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
                <ListItem onClick={() => navigate("/Offers")}>
                    <ListItemButton>
                        <ListItemDecorator><Inventory/></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"offers"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
                <ListItem onClick={() => navigate("/Feedback")}>
                    <ListItemButton>
                        <ListItemDecorator><Feedback/></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"feedback"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
                <ListItem onClick={() => navigate("/Model")}>
                    <ListItemButton>
                        <ListItemDecorator><ListAlt/></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"oModel"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
            </List>
            </Grid>

            { session.role === "Admin" && <Divider variant="middle" textColor={"text.primary"} > 
                <Chip
                    color="neutral"
                    size="sm"
                    variant="outlined"
                >
                    <Trans i18nKey={"administrating"}/>
                </Chip>
            </Divider> }

            { session.role === "Admin" && <Grid container>
            <List p={2}>
                <ListItem onClick={() => navigate("/Plants")}>
                    <ListItemButton>
                        <ListItemDecorator><Grass /></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"plants"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
                <ListItem onClick={() => navigate("/Substrates")}>
                    <ListItemButton>
                        <ListItemDecorator><Gradient /></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"substrates"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
                <ListItem onClick={() => navigate("/Packs")}>
                    <ListItemButton>
                        <ListItemDecorator><Inventory/></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"packs"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
                <ListItem onClick={() => navigate("/Devices")}>
                    <ListItemButton>
                        <ListItemDecorator><SpeakerPhone /></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"devices"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
                <ListItem onClick={() => navigate("/Statistic")}>
                    <ListItemButton>
                        <ListItemDecorator><InsertChart /></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"statistic"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
                <ListItem onClick={() => navigate("/Orders")}>
                    <ListItemButton>
                        <ListItemDecorator><ListAlt /> </ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"orders"}/></ListItemContent>
                    </ListItemButton>
                </ListItem>
            </List>
            </Grid>}

            <Divider variant="middle" />

            <Grid container>
            <List p={2}>
                { session.token && <ListItem onClick={() => logOut()}>
                    <ListItemButton>
                        <ListItemDecorator><Logout /></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"logOut"}/></ListItemContent>
                    </ListItemButton>
                </ListItem> }
                { !session.token && <ListItem onClick={() => navigate("/Login")}>
                    <ListItemButton>
                        <ListItemDecorator><Login /></ListItemDecorator>
                        <ListItemContent><Trans i18nKey={"logIn"}/></ListItemContent>
                    </ListItemButton>
                </ListItem> }
            </List>
            </Grid>


        </Stack>
    )
}