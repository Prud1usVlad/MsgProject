import React, { useState, useEffect } from 'react';
import Button from '@mui/joy/Button';
import FormControl from '@mui/joy/FormControl';
import FormLabel from '@mui/joy/FormLabel';
import Input from '@mui/joy/Input';
import Modal from '@mui/joy/Modal';
import ModalDialog from '@mui/joy/ModalDialog';
import Stack from '@mui/joy/Stack';
import Typography from '@mui/joy/Typography';
import ModalClose from '@mui/joy/ModalClose';
import { Trans } from 'react-i18next';
import axios from "axios";
import { Grid, Textarea } from '@mui/joy';
import ModalOverflow from '@mui/joy/ModalOverflow';



export default function DetailsModal(props) {

    const [open, setOpen] = useState(props.open);
    const [data, setData] = useState(props.config.dataModel);

    useEffect(() =>{
        if (props.open) {
            setOpen(true);
            fetchData()
        }
    }, [props.open])

    const fetchData = async () => {
        if (props.selectedId === 0) {
            setData(props.config.dataModel);
            return;
        }

        let responce = await axios.get(props.config.controllerAddress + props.selectedId, props.headers);
        console.log(responce);
        setData(responce.data);
    }

    const generateField = (property, key, value) => {
        
        if (property.type === "string") {
            return(
                <FormControl key={key}>
                    <FormLabel><Trans i18nKey={property.label} /></FormLabel>
                    <Input disabled={ property.disabled } 
                        value={data[property.name]} 
                        onChange={e => updateData(property.name, e.target.value)} />
                </FormControl>
            )
        }
        else if (property.type === "text") {
            return(
                <FormControl key={key}>
                    <FormLabel><Trans i18nKey={property.label} /></FormLabel>
                    <Textarea minRows={2}
                        maxRows={4}
                        disabled={ property.disabled } 
                        value={data[property.name]} 
                        onChange={e => updateData(property.name, e.target.value)} />
                </FormControl>
            )
        }
        else if (property.type === "custom") {
            if (value === undefined)
                return <></>
            return (
                <>
                    <FormLabel><Trans i18nKey={property.label} /></FormLabel>
                    {property.generate(value, data, (data) => setData(data))}
                </>
            )
        }
        else {
            return <></>
        }
    }

    const onClose = () => { setOpen(false); props.onClose(); }

    const updateData = (field, value) => {
        let newObj = {};
        Object.assign(newObj, data);

        newObj[field] = value;

        setData(newObj);
    }

    return(
        <Modal open={open} onClose={onClose} variant="outlined">
        <ModalOverflow>
        <ModalDialog
            aria-labelledby="basic-modal-dialog-title"
            aria-describedby="basic-modal-dialog-description"
            sx={{ maxWidth: 700, minWidth: 400 }}
        >
            <ModalClose
                variant="outlined"
                sx={{
                    top: 'calc(-1/4 * var(--IconButton-size))',
                    right: 'calc(-1/4 * var(--IconButton-size))',
                    boxShadow: '0 2px 12px 0 rgba(0 0 0 / 0.2)',
                    borderRadius: '50%',
                    bgcolor: 'background.body',
                }}
            />
            <Typography id="basic-modal-dialog-title" component="h2">
                <Trans i18nKey={props.config.header}/>
            </Typography>
            <Typography id="basic-modal-dialog-description" textColor="text.tertiary">
                <Trans i18nKey={props.config.subheader}/>
            </Typography>
            <Stack spacing={2}>

                {props.config.properties.map((item, index) => {
                    return generateField(item, index, data[item.name]);
                })}

                <Grid container>
                    <Button color="info" size='lg' sx={{ mr: 2 }} onClick={onClose}><Trans i18nKey={"back"} /></Button>
                    { 
                        (props.config.showSubmit) ? 
                            (<Button 
                                type="submit" 
                                size='lg' 
                                sx={{ mr: 2 }}
                                onClick={() => { 
                                    props.config.submitAction(data, props.config.controllerAddress, props.headers);
                                    onClose();
                                }}>
                                    <Trans i18nKey={"submit"} />
                            </Button>) : 
                            <></> 
                    }
                </Grid>
            </Stack>
        </ModalDialog>
        </ModalOverflow>
        </Modal>
    )
}

