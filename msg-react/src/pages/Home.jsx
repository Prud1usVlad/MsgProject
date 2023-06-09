import { Button, Stack, Typography,  Card, CardContent, CardCover, Grid, Divider, Box } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";
import { green, grey } from '@mui/material/colors';
import { useNavigate } from 'react-router-dom';


export default function Home() {
    const { t, i18n } = useTranslation();

    const changeLanguage = (lng) => {
        i18n.changeLanguage(lng);
    };

    const navigate = useNavigate();


    return (
        <Card sx={{ height:"96%", width: "96%", m: 2 }}>
            <CardCover>
                <img
                src="https://integrisok.com/-/media/Blog/21-Q3/OYH_microgreens.ashx?as=1&mh=405&mw=720&revision=7d364ff0-7c9a-4508-935d-6f49f4f7aa97&hash=E4D31DC6EC44D4BE5D8E5FC2FD917430"
                loading="lazy"
                alt=""
                />
            </CardCover>
            <CardCover
                sx={{
                background:
                    'linear-gradient(to top, rgba(0,0,0,0.4), rgba(0,0,0,0) 200px), linear-gradient(to top, rgba(0,0,0,0.8), rgba(0,0,0,0) 300px)',
                }}
            />
            <CardContent sx={{ justifyContent: 'flex-end' }}>
                <Grid container
                    bgcolor={"rgba(0,0,0,0.45)"}
                    sx={{ p: 2, borderRadius: 10 }}>
                    <Grid xs={7}>
                        <Typography level="h2" textColor="#fff" mb={1}>
                            Micro and Soft Greens
                        </Typography>
                        <Divider variant="middle"/>
                        <Typography
                            textColor="neutral.300"
                        >
                            <Trans i18nKey={"lorem"}/>
                        </Typography>
                    </Grid>
                    <Grid xs={5} 
                        container 
                        justifyContent="flex-end"
                        alignItems="flex-end">
                        <Box>
                        <Button variant="outlined" 
                            color="info"
                            size="lg"
                            onClick={() => navigate("/Offers")}>
                            <Trans i18nKey={"toOffers"}/>
                        </Button>
                        </Box>
                    </Grid>
                </Grid>
            </CardContent>
        </Card>
    );
}