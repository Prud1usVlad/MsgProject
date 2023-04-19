import { Button } from "@mui/joy";
import { useTranslation, Trans } from "react-i18next";


export default function Home() {
    const { t, i18n } = useTranslation();

    const changeLanguage = (lng) => {
        i18n.changeLanguage(lng);
    };


    return (
        <>
            <Button variant="solid"></Button>
            <Button variant="soft">Soft</Button>
            <Button variant="outlined">Outlined</Button>
            <Button variant="plain">Plain</Button>
        </>
    );
}