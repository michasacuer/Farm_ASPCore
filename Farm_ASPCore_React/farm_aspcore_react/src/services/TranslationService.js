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
      return value === 0 ? "Kierowca" : "Farmer";
    case "grain":
      switch (value) {
        case 0:
          return "brak";
        case 1:
          return "ryż";
        case 2:
          return "kukurydza";
        case 3:
          return "owies";
        default:
          return value;
      }
    case "salary":
      return value.toFixed(2) + " zł";
    case "species":
      return value === 0 ? "Czarny" : "Biały";
    case "strategia":
      return value === 0 ? "Uprawa" : "Farma";
    default:
      return value;
  }
}
export default translate;
