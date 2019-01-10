export default function translate(key) {
  let translation = "";
  switch (key) {
    case "salary":
      translation = "Płaca";
      break;
    case "id":
      translation = "Id";
      break;
    case "farmId":
      translation = "Id farmy";
      break;
    case "farm":
      translation = "Farma";
      break;
    case "firstName":
      translation = "Imię";
      break;
    case "lastName":
      translation = "Nazwisko";
      break;
    case "startOfContract":
      translation = "Początek umowy";
      break;
    case "endOfContract":
      translation = "Koniec umowy";
      break;
    case "usdPerHour":
      translation = "Płaca (USD/H)";
      break;
    case "hoursPerDay":
      translation = "Godziny dziennie";
      break;
    case "daysOfWork":
      translation = "Ilość dni pracy w miesiącu";
      break;
    case "baseSalary":
      translation = "Podstawowa płaca";
      break;

    default:
      translation = key;
      break;
  }
  return translation;
}
