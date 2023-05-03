import { BrowserRouter, Routes, Route, Navigate, useParams, useNavigate } from "react-router-dom";
import { Button, Stack, Typography,  Card,  Divider, Box, AspectRatio, Chip, FormControl, FormLabel, Input,  Autocomplete, AutocompleteOption, ListItemDecorator, ListItemContent, List, ListItem, Table } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";
import { useState, useEffect } from 'react';
import { apiConfig } from "../config/apiConfig";
import axios from "axios";
import * as React from 'react';
import WarningIcon from '@mui/icons-material/Warning';
import Alert from '@mui/joy/Alert';
import { globalError, orderSuccess } from "../config/modalConfig";
import InfoModal from "../components/InfoModal";

const session = JSON.parse(localStorage.getItem("session")) || {};
const headers = { headers: { 'Authorization': `Bearer ${session.token}`}};
const API_URL = apiConfig.url;

export default function OptModel(props){

    const [ X, setX ] = useState(5);
    const [ Y, setY ] = useState(10);
    const [ Z, setZ ] = useState(0.1);
    
    const [ V, setV ] = useState(5);
    const [ D, setD ] = useState(0.1);

    const [ sPlant, setSPlant ] = useState({ characteristics: []});
    const [ sSubstrates, setSSubstrates ] = useState([]);

    const [ plants, setPlants ] = useState([])
    const [ substrates, setSubstrates ] = useState([])

    const [ showModal, setShowModal ] = useState(false);
    const [ result, setResult ] = useState(null);


    const { t, i18n } = useTranslation();

    const updateV = () => {
        setV((X * Y * Z));
    }

    const optimize = async () => {
        try {
            let body = {
                "selectedPlantID": sPlant.id,
                "selectedSubstratesId": sSubstrates.map(s => s.id),
                "substrateVolume": V,
                "deviation": D
            }

            let response = await axios.post(API_URL + "OptimizingModel/", body, headers);
            setResult(response.data);
            console.log(response.data)
        }
        catch {
            setShowModal(true);
        }
    }

    useEffect(() => {
        async function fetchData() {
            // For testing purposes changed to testing data
            let pl = await axios.get(API_URL + "Plants/" , headers);
            let sub = await axios.get(API_URL + "Substrates/" , headers);
            setPlants(pl.data);
            setSubstrates(sub.data);

            console.log(pl.data);
            updateV()
        }

        fetchData();
    }, []);

    var check = (cons, sub) => {
        let success = true;
        let sum = 0;
        let res = {}

        for (let i = 0; i < cons.length; i++) {
            let upperSum = 0;
            
            for (let j = 0; j < sub.length; j++) {
                upperSum += sub[j].val[i].value * sub[j].v;
            }
    
            let val = ((Math.abs((upperSum / V) - cons[i].v)) / cons[i].v).toFixed(3);
            sum += parseFloat(val);

            if (D <= val) {
                console.log(`cons ${i}:  ${val * 100}% | failed`);
                success = false
            }
            else {
                console.log(`cons ${i}:  ${val * 100}%`);
            }

            res[cons[i].name] = (upperSum / V);
        }

        res["Success"] = success ? 1 : 0;
        res["Deviation"] = sum / cons.length;

        return res;
    }

    return (
        <Stack p={3} >
            <InfoModal 
                open={showModal} 
                config={globalError} 
                onClose={() => setShowModal(false) }
            />

            <Typography level="h2" my={3}><Trans i18nKey={"oModel"}/></Typography>
            
            <Divider variant="middle" >
                <Chip variant="outlined" color="info">
                    <Trans i18nKey={"step"}/> #1 | <Trans i18nKey={"step1"}/>
                </Chip>
            </Divider>

            <Autocomplete
                my={3}
                placeholder={t("plants")}
                options={plants}
                sx={{ width: "50%" }}
                getOptionLabel={(option) => option.name}
                onChange={(event, newValue) => {
                    setSPlant(newValue);
                }}
                renderOption={(props, option) => (
                    <AutocompleteOption {...props}>
                        <ListItemDecorator>
                            <img
                                loading="lazy"
                                width="40"
                                src={option.photoUrl}
                                alt=""
                            />
                        </ListItemDecorator>
                        <ListItemContent sx={{ fontSize: 'sm' }}>
                            <Typography level="body1" mx={2}>
                                { option.name }
                            </Typography>
                        </ListItemContent>
                    </AutocompleteOption>
                )}
            />

            <Typography level="h3" my={2}>
                <Trans i18nKey={"sPlant"} />
            </Typography>

            { sPlant !== null && sPlant.id !== undefined && <Card
                variant="outlined"
                orientation="horizontal"
                sx={{
                    width: "50%",
                    gap: 2,
                    mb: 2
                }}
            >
                <AspectRatio ratio="1" sx={{ width: 100 }}>
                    <img
                        src={sPlant.photoUrl}
                        loading="lazy"
                        alt=""
                    />
                </AspectRatio>
                <div>
                    <Typography level="h6" mb={0.5}>
                        {sPlant.name}
                    </Typography>
                    <Typography level="body3" mb={0.5}>
                        {sPlant.description}
                    </Typography>
                    <Stack direction="row" spacing={2}>
                        {sPlant.characteristics.map((e, i) => {
                            return(
                                <Chip key={i} variant="outlined" color="success" m={2} size="sm">{e.name} : {e.value}</Chip>
                            )
                        })}
                    </Stack>
                </div>
            </Card>}

            <Divider variant="middle">
                <Chip variant="outlined" color="info">
                    <Trans i18nKey={"step"}/> #2 | <Trans i18nKey={"step2"}/>
                </Chip>
            </Divider>

            <Autocomplete
                my={3}
                placeholder={t("substrates")}
                options={substrates}
                sx={{ width: "50%" }}
                getOptionLabel={(option) => option.name}
                onChange={(event, newValue) => {
                    setSSubstrates(newValue)
                }}
                multiple
                renderOption={(props, option) => (
                    <AutocompleteOption {...props}>
                        <ListItemDecorator>
                            <img
                                loading="lazy"
                                width="40"
                                src={option.photoUrl}
                                alt=""
                            />
                        </ListItemDecorator>
                        <ListItemContent sx={{ fontSize: 'sm' }}>
                            <Typography level="body1" mx={2}>
                                { option.name }
                            </Typography>
                            <Typography level="body3" mx={2}>
                                <Trans i18nKey={"price"} />: { option.price } $
                            </Typography>
                        </ListItemContent>
                    </AutocompleteOption>
                )}
            />

            <Typography level="h3" my={2}>
                <Trans i18nKey={"sSub"} />
            </Typography>

            {sSubstrates.map((e, i) => {
                return (
                    <Card
                        key={i}
                        variant="outlined"
                        orientation="horizontal"
                        sx={{
                            width: "50%",
                            gap: 2,
                            mb: 2
                        }}
                    >
                        <AspectRatio ratio="1" sx={{ width: 100 }}>
                            <img
                                src={e.photoUrl}
                                loading="lazy"
                                alt=""
                            />
                        </AspectRatio>
                        <div>
                            <Typography level="h6" mb={0.5}>
                                {e.name}
                            </Typography>
                            <Typography level="body3" mb={0.5}>
                                {e.description}
                            </Typography>
                            <Stack direction="row" spacing={2} mb={0.5}>
                                {e.characteristics.map((e, i) => {
                                    return(
                                        <Chip key={i} variant="outlined" color="success" m={2} size="sm">{e.name} : {e.value}</Chip>
                                    )
                                })}
                            </Stack>
                            <Stack direction="row" spacing={2}>
                                <Typography level="body3" mb={0.5}>
                                    <Trans i18nKey={"price"} />: { e.price } $
                                </Typography>
                                <Typography level="body3" mb={0.5}>
                                    <Trans i18nKey={"volume"} />: { e.volume }
                                </Typography>
                            </Stack>
                        </div>
                    </Card>
                )
            })}

            <Divider variant="middle">
                <Chip variant="outlined" color="info">
                    <Trans i18nKey={"step"}/> #3 | <Trans i18nKey={"step3"}/>
                </Chip>
            </Divider>

            <Typography level="h3" my={2}>
                <Trans i18nKey={"fSpace"} />
            </Typography>

            <Stack direction={"row"} gap={2} mb={2} justifyContent="center" alignItems="center">
                <FormControl>
                    <Input 
                        type="number" 
                        value={X}
                        sx={{ width: 100 }}
                        onChange={(e) => {
                            setX(e.target.value);
                            setV(e.target.value * Y * Z);
                        }}
                        slotProps={{
                            input: {
                              min: 0,
                              step: 0.1,
                            },
                        }} />
                </FormControl>
                
                <Typography level="h5">X</Typography>

                <FormControl>
                    <Input 
                        type="number" 
                        value={Y}
                        sx={{ width: 100 }}
                        onChange={(e) => {
                            setY(e.target.value);
                            setV(e.target.value * X * Z);
                        }}
                        slotProps={{
                            input: {
                              min: 0,
                              step: 0.1,
                            },
                        }} />
                </FormControl>
                
                <Typography level="h5">X</Typography>

                <FormControl>
                    <Input 
                        type="number" 
                        value={Z}
                        sx={{ width: 100 }}
                        onChange={(e) => {
                            setZ(e.target.value);
                            setV(e.target.value * X * Y);
                        }}
                        slotProps={{
                            input: {
                              min: 0,
                              step: 0.1,
                            },
                        }} />
                </FormControl>
                
                <Typography level="h5">=</Typography>

                <Typography level="h5">{V} m<sup>3</sup> </Typography>


            </Stack>

            <Divider variant="middle">
                <Chip variant="outlined" color="info" >
                    <Trans i18nKey={"step"}/> #4 | <Trans i18nKey={"step4"}/>
                </Chip>
            </Divider>

            <Typography level="h3" my={2}>
                <Trans i18nKey={"deviation"} />
            </Typography>

            <FormControl sx={{ mb: 2}}>
                <Input 
                    type="number" 
                    value={D}
                    sx={{ width: 100 }}
                    onChange={(e) => {
                        setD(e.target.value);
                    }}
                    slotProps={{
                        input: {
                            min: 0.05,
                            step: 0.01,
                        },
                    }} />
            </FormControl>

            <Divider variant="middle" />

            <Box my={2}>
                <Button 
                    variant="outlined" 
                    color="success" 
                    size="lg"
                    onClick={ () => optimize() }>
                    <Trans i18nKey={"process"}/>
                    </Button>
            </Box>

            { result !== null && 
                <Stack my={2}> 
                    <Divider variant="middle" />

                    <Typography level="h3" my={2}>
                        <Trans i18nKey={result.isSucceed ? "omSuccess" : "omFailed"} />
                    </Typography>

                    <Divider variant="middle" />

                    <Typography level="h3" my={2}>
                        <Trans i18nKey={result.isSucceed ? "res" : "bfVar"} />
                    </Typography>

                    <Stack direction="row" gap={2} useFlexGap flexWrap="wrap">
                        {result.result.map((e, i) => {
                            if (e.volume === 0)
                                return null;

                            return (
                                <Card
                                    key={i}
                                    variant="outlined"
                                    orientation="horizontal"
                                    sx={{
                                        width: 300,
                                        gap: 2,
                                        mb: 2
                                    }}
                                >
                                    <div>
                                        <Typography level="h6" mb={0.5}>
                                            {e.substrate.name}
                                        </Typography>
                                        <Typography level="body1" mb={0.5}>
                                            <Trans i18nKey={"volume"} />: {e.volume} m<sup>3</sup>
                                        </Typography>
                                        <Stack direction="row" spacing={2}>
                                            <Typography level="body3" mb={0.5}>
                                                <Trans i18nKey={"price"} />: { e.substrate.price } $
                                            </Typography>
                                            <Typography level="body3" mb={0.5}>
                                                <Trans i18nKey={"amount"} /> <Trans i18nKey={"packages"} /> : { e.packsAmount } 
                                            </Typography>
                                        </Stack>
                                    </div>
                                </Card>
                            )
                        })}

                        <Typography level="h5" my={2}>
                            <Trans i18nKey={"tPrice"} /> { parseFloat(result.price).toFixed(2) } $
                        </Typography>

                        <Typography level="h5" my={2}>
                            <Trans i18nKey={"deviation"} /> { parseFloat(result.deviation * 100).toFixed(3) } %
                        </Typography>

                    </Stack>

                    <Divider variant="middle" />

                    <Typography level="h3" my={2}>
                        <Trans i18nKey={"steps"} />
                    </Typography>

                    { result.result.map((e, i) => {
                        let tableValues = []
                        let sub = []

                        for (let j = 0; j < result.result.length; j++) {
                            let substrate = substrates.find(s => s.id === result.result[j].substrate.id)

                            if (j <= i) {
                                tableValues.push({v: result.result[j].volume, color: "success"})

                                sub.push({v: result.result[j].volume, val: substrate.characteristics})
                            }
                            else {
                                tableValues.push({v: 0, color: "danger"})

                                sub.push({v: 0, val: substrate.characteristics})
                            }
                        }

                        let additional = check(sPlant.characteristics.map(el => { return ({name: el.name, v: el.value})}), sub);
                        let addArray = []

                        for (const prop in additional) {
                            addArray.push({name: prop, val: additional[prop]});
                        }


                        return (
                            <Box>
                                <Typography level="h3" my={2}>
                                    <Trans i18nKey={"step"} /> №{i + 1}
                                </Typography>

                                <Table variant="soft" borderAxis="bothBetween">
                                    <thead>
                                        <tr>
                                            {result.result.map(s => <th>{s.substrate.name} | {t("price") + s.substrate.price + "$"}</th>)}
                                            {addArray.map(prop => <th>{prop.name}</th>)}
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            {tableValues.map(el => <td ><Chip size="lg" color={el.color}>{el.v}</Chip></td>)}
                                            {addArray.map(prop => <td>{parseFloat(prop.val).toFixed(3)}</td>)}
                                        </tr>
                                    </tbody>
                                </Table>
                            </Box>
                        )
                    })}

                </Stack>
            }
        </Stack>

        
    )
}