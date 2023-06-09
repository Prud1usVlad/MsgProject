import { Typography, Modal, Sheet, ModalClose, Alert } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";
import { useState, useEffect } from 'react';
import * as React from "react"
import InfoIcon from '@mui/icons-material/Info';
import WarningIcon from '@mui/icons-material/Warning';
import ReportIcon from '@mui/icons-material/Report';
import CheckCircleIcon from '@mui/icons-material/CheckCircle';



export default function InfoModal(props) {

    const [open, setOpen] = useState(props.open);

    const icons = {
        info: <InfoIcon />,
        warning: <WarningIcon />,
        danger: <ReportIcon />,
        success: <CheckCircleIcon />
    }

    useEffect(() =>{
        if (props.open) {
            setOpen(true);
        }
    }, [props.open])

    return(
        <Modal
            aria-labelledby="modal-title"
            aria-describedby="modal-desc"
            open={open}
            onClose={() => { setOpen(false); props.onClose() }}
            sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}
        >
            <Sheet
                variant="outlined"
                sx={{
                    maxWidth: 500,
                    borderRadius: 'md',
                    p: 3,
                    boxShadow: 'lg',
                }}
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
            <Typography
                component="h2"
                id="modal-title"
                level="h4"
                textColor="inherit"
                fontWeight="lg"
                mb={1}
            >
                <Trans i18nKey={props.config.header}/>
            </Typography>

            <Alert
                sx={{ alignItems: 'flex-start' }}
                startDecorator={React.cloneElement(icons[props.config.variant], {
                    sx: { mt: '2px', mx: '4px' },
                    fontSize: 'xl2',
                })}
                variant="soft"
                color={props.config.variant}
                >
                <div>
                    <Typography fontSize="sm" sx={{ opacity: 0.8 }}>
                        <Trans i18nKey={props.config.text} />
                    </Typography>
                </div>
            </Alert>
            </Sheet>
        </Modal>

    )
}