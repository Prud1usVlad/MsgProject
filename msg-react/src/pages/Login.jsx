import { useState } from 'react';
import { Stack, Input, Button, Grid, Typography, FormControl, FormLabel, Box } from "@mui/joy"
import { useTranslation, Trans } from "react-i18next";
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import { apiConfig } from '../config/apiConfig';
import * as React from 'react';
import WarningIcon from '@mui/icons-material/Warning';
import Alert from '@mui/joy/Alert';

export default function Login() {
    const { t, i18n } = useTranslation();
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [displayAlert, setDisplayAlert] = useState(false);
    const navigate = useNavigate();
  
    const handleUserNameChange = (event) => {
      setUserName(event.target.value);
    };
  
    const handlePasswordChange = (event) => {
      setPassword(event.target.value);
    };

    const onSubmit = async () => {
        try {
            let response = await axios.post(apiConfig.url + "Authentication/login", { password:password, userName:userName });

            const claims = JSON.parse(atob(response.data.token.split('.')[1]))

            const session = {
                token: response.data.token,
                userId: response.data.userId,
                role: claims["role"],
                due: claims["iat"],
            }

            localStorage.setItem("session", JSON.stringify(session));

            navigate("/");
        }
        catch {
            setDisplayAlert(true);
        }

        setPassword("");
    }
  
    return (
        <Grid container 
            height={"100%"}
            alignItems="center">
            <Grid sm={3.5}></Grid>
            <Grid sm={5} 
                bgcolor={"background.level1"}
                boxShadow="md"
                borderRadius={"md"}>
                <Stack p={3}
                    spacing={4}>
                    <Typography level='h4'><Trans i18nKey={"loginHeader"}/></Typography>

                    {displayAlert && <Alert
                        sx={{ alignItems: 'flex-start' }}
                        startDecorator={React.cloneElement(<WarningIcon />, {
                            sx: { mt: '2px', mx: '4px' },
                            fontSize: 'xl2',
                        })}
                        variant="soft"
                        color={"warning"}
                        >
                        <div>
                            <Typography fontWeight="lg" mt={0.25}>
                                <Trans i18nKey={"error"}/>
                            </Typography>
                            <Typography fontSize="sm" sx={{ opacity: 0.8 }}>
                                <Trans i18nKey={"loginError"} />
                            </Typography>
                        </div>
                    </Alert>}


                    <FormControl m={2}>
                        <FormLabel><Trans i18nKey={"login"}/></FormLabel>
                        <Input placeholder={t("login")}
                            value={userName}
                            onChange={(e) => setUserName(e.target.value)} />
                    </FormControl>
                    <FormControl m={2}>
                        <FormLabel><Trans i18nKey={"password"}/></FormLabel>
                        <Input placeholder={t("password")} 
                            type='password'
                            value={password}
                            onChange={(e) => setPassword(e.target.value)} />
                    </FormControl>
                    <Box>
                        <Button onClick={onSubmit}><Trans i18nKey={"submit"}/></Button>
                    </Box>
                </Stack>
            </Grid>
            <Grid sm={3.5}></Grid>
        </Grid>
    );
};