function translate(key) {
  switch (key) {
    case "salary":
      return "Płaca";
    case "id":
      return "Id";
    case "farmId":
      return "Id farmy";
    case "farm":
      return "Farma";
    case "firstName":
      return "Imię";
    case "lastName":
      return "Nazwisko";
    case "startOfContract":
      return "Początek umowy";
    case "endOfContract":
      return "Koniec umowy";
    case "usdPerHour":
      return "Płaca (USD/H)";
    case "hoursPerDay":
      return "Godziny dziennie";
    case "daysOfWork":
      return "Ilość dni pracy w miesiącu";
    case "baseSalary":
      return "Podstawowa płaca";
    case "species":
      return "Gatunek";
    case "sex":
      return "Płeć";
    default:
      return key;
  }
}
export function cellDataTranslate(key, value) {
  switch (key) {
    case "sex":
      return value === 0 ? "Samica" : "Samiec";
    case "kind":
      return value === 0 ? "Driver" : "Farmer";
    default:
      return value;
  }
}
export default translate;
