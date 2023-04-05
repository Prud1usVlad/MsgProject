import i18n from "i18next";
import LanguageDetector from "i18next-browser-languagedetector";
import { initReactI18next } from "react-i18next";

i18n
  .use(LanguageDetector)
  .use(initReactI18next)
  .init({
    // we init with resources
    resources: {
      en: {
        translations: {
          email:"Email",
          password: "Password",
          submit: "Submit",
          loginHeader: "System authorization",
          menue: "Menue",
          name: "Name",
          lastName:"Last name",
          lang:"Interface language",
          actions: "Actions",
          delete: "Delete",
          add: "Add",
          details: "Details",
          phone: "Phone number",
          save: "Save changes",
          back: "Back",
          basicData: "Basic data",
          charts: "Charts",
          search: "Search",
          onDelete: "Do you rely want to delete?",
          loginError: "An error occurred in process of authorization, please check your credentials.",
          accessDenied: "Resource access denied to this account.",
          adminPanelHeader: "Adminpanel",
          desc:"Description",
          title:"Title",
          value: "Value: ",
          home:"Home page",
          stat:"Statistics page",
          logout:"Log out",
          id: "Identifier",
          address: "Address",
          noItemSelected: "Please select item in the list",
          send: "Send",
          addDp: "Add data piece",
          dpList: "Data pieces list",
          units: "Measure units",
          labels: "Labels",
          dmh_dpCreate: "Create new Data Piece",
          dmsh_dpCreate: "Fill in the fields and submit.",
          dmh_dpDetails: "Detailed view",
          dmsh_dpDetails: "All properties of Data Piece",
          dmh_sCreate: "Create new Substrate",
          dmsh_sCreate: "Fill in the fields and submit.",
          dmh_sDetails: "Detailed view",
          dmsh_sDetails: "All properties of Substrate",
          dmh_pCreate: "Create new Plant",
          dmsh_pCreate: "Fill in the fields and submit.",
          dmh_pDetails: "Detailed view",
          dmsh_pDetails: "All properties of Plant",
          sList: "Substrates list",
          price:"Price",
          volume:"Volume",
          chars:"Characteristics",
          pList: "Plants list",
          reload: "Reload",
        }
      },
      ua: {
        translations: {
            email:"Електронна пошта",
            password: "Пароль",
            submit: "Відправити",
            loginHeader: "Авторизація в системі",
            menue: "Меню",
            name: "Ім'я",
            lastName:"Прізвище",
            lang:"Мова інтерфесу",
            actions: "Дії",
            delete: "Видалити",
            add:"Додати",
            details: "Детальніше",
            phone: "Номер телефону",
            save: "зберегти зміни",
            back: "Назад",
            basicData: "Базова інформація",
            charts: "Графіки",
            search: "Шукати",
            onDelete: "Ви дійсно хочете видалити?",
            chartWarning: "Сталася помилка під час спроби отримати дані графіку для поточного користувача. Перевірки правильність введених даних або спробуйте ще раз пізніше.",
            loginError: "Сталася помилка під час авторизації, перевірте введені дані.",
            accessDenied: "Для цього аккаунту доступ до ресурсу заборонений.",
            desc:"Описання",
            title:"Назва",
            value: "Значення: ",
            home:"Домашня сторінка",
            stat:"Сторінка статистики",
            sens:"Сторінка сенсорів",
            logout:"Вийти з аккаунту",
            id: "Ідентифікатор",
            noItemSelected: "Будь ласка оберіть елемент зі списку",
            send: "Надіслати",
            addDp: "Додати властивість",
            dpList: "Список властивостей",
            units: "Одиниці виміру",
            labels: "Мітки",
            dmh_dpCreate: "Створити нову властивість",
            dmsh_dpCreate: "Заповніть поля та відправте.",
            dmh_dpDetails: "Детальний перегляд",
            dmsh_dpDetails: "Всі поля сутності 'Властивість'",
            dmh_sCreate: "Створити субстрат",
            dmsh_sCreate: "Заповніть поля та відправте.",
            dmh_sDetails: "Детальний перегляд",
            dmsh_sDetails: "Всі властивості субстрату",
            dmh_pCreate: "Створити рослину",
            dmsh_pCreate: "Заповніть поля та відправте.",
            dmh_pDetails: "Детальний перегляд",
            dmsh_pDetails: "Всі властивості рослини",
            sList: "Список субстратів",
            price: "Ціна",
            volume: "Об'єм",
            chars: "Характеристики",
            pList: "Список рослин",
            reload: "Оновити",
        }
      }
    },
    fallbackLng: "en",
    debug: true,

    // have a common namespace used around the full app
    ns: ["translations"],
    defaultNS: "translations",

    keySeparator: false, // we use content as keys

    interpolation: {
      escapeValue: false
    }
  });

export default i18n;