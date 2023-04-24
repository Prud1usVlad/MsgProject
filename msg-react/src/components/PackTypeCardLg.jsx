import * as React from 'react';
import AspectRatio from '@mui/joy/AspectRatio';
import Avatar from '@mui/joy/Avatar';
import Box from '@mui/joy/Box';
import Card from '@mui/joy/Card';
import IconButton from '@mui/joy/IconButton';
import Typography from '@mui/joy/Typography';
import Link from '@mui/joy/Link';
import FavoriteBorderRoundedIcon from '@mui/icons-material/FavoriteBorderRounded';
import { Divider, Stack, Chip, Grid, Button  } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";

export default function PackTypeCardLg(props) {
  return (
    <Box sx={{ minHeight: 350 }}>
      <Card
        variant="outlined"
        sx={(theme) => ({
          width: 960,
          gridColumn: 'span 2',
          flexDirection: 'row',
          flexWrap: 'wrap',
          overflow: 'hidden',
          gap: 'clamp(0px, (100% - 360px + 32px) * 999, 16px)',
          transition: 'transform 0.3s, border 0.3s',
          //'& > *': { minWidth: 'clamp(0px, (360px - 100%) * 999,100%)' },
          '& > *': { minWidth: "480px"}
        })}
      >
        <AspectRatio
          variant="soft"
          sx={{
            flexGrow: 1,
            display: 'contents',
            '--AspectRatio-paddingBottom':
              'clamp(0px, (100% - 360px) * 999, min(calc(100% / (16 / 9)), 300px))',
          }}
        >
          <img
            src={props.packType.image}
            loading="lazy"
            alt=""
          />
        </AspectRatio>
        <Box
          sx={{
            display: 'flex',
            flexDirection: 'column',
            gap: 2,
            maxWidth: 400,
          }}
        >
            <Stack>
                <Typography level='h4' my={3}>
                    {props.packType.name}
                </Typography>

                <Divider variant="middle"/>

                <Typography level='body' my={2}>
                    {props.packType.description}
                </Typography>

                <Divider variant="middle" />

                <Typography level='h6' my={1}>
                    <Trans i18nKey="devices" /> :
                </Typography>

                {props.packType.devicesInPack.map((item, index) => {
                    return (
                    <Card
                        key={index}
                        variant="outlined"
                        orientation="horizontal"
                        sx={{
                            width: 300,
                            gap: 2,
                            my: 1
                        }}
                    >
                        <AspectRatio ratio="1" sx={{ width: 65 }}>
                            <img
                                src={item.image}
                                loading="lazy"
                                alt=""
                            />
                        </AspectRatio>
                        <div>
                            <Typography level="h1" fontSize="lg" id="card-description" mb={0.5}>
                                {item.name}
                            </Typography>
                            <Chip
                                variant="outlined"
                                color="success"
                                size="md"
                                sx={{ pointerEvents: 'none' }}
                            >
                                X{item.amount}
                            </Chip>
                        </div>
                    </Card>
                    )
                })}

                <Divider variant="middle" />

                <Grid container 
                  justifyContent="space-between"
                  alignItems="center" 
                  px={3} pt={2}>
                    <Typography level="h4">
                      <Trans i18nKey={"tPrice"}/> { props.getPrice() }
                    </Typography>
                    
                    <Button 
                        color="success"
                        size='lg'
                        px={4}
                        onClick={props.onOrder}>
                            <Trans i18nKey={"order"} />
                    </Button>
                </Grid>

            </Stack>
        </Box>
      </Card>
    </Box>
  );
}