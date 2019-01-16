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
    case "budget":
      return "Budżet";
    case "machinesCost":
      return "Rozliczenie maszyn";
    case "workersCost":
      return "Rozliczenie pracowników";
    case "animalsCost":
      return "Rozliczenie zwierząt";
    case "cultivationsCost":
      return "Rozliczenie upraw";
    case "summaryCost":
      return "Bilans";
    case "summaryDate":
      return "Data faktury";
    case "kind":
      return "Praca";
    case "grain":
     return "Uprawiane zboże";
    case "compositeId":
      return "Id kompozytu";
    case "acreage":
      return "Powierzchnia";
    case "mappedStrategy":
      return "Strategia";
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
          return "Brak";
        case 1:
          return "Ryż";
        case 2:
          return "Kukurydza";
        case 3:
          return "Otręby";
        default:
          return value;
      }
    case "salary":
      return value.toFixed(2) + " zł";
    case "species":
      return value === 0 ? "Czarny" : "Biały";
    case "mappedStrategy":
      return value === 0 ? "Praca w polu" : "Praca na farmie";
    case "budget":
      return value.toFixed(2) + " zł";
    case "machineCost":
      return value.toFixed(2) + " zł";
    case "animalsCost":
      return value.toFixed(2) + " zł";
    case "workersCost":
      return value.toFixed(2) + " zł";
    case "cultivationsCost":
      return value.toFixed(2) + " zł";
    case "summaryCost":
      return value.toFixed(2) + " zł";
    case "summaryDate":
      return Date.parse(value);
    
    default:
      return value;
  }
}
export default translate;
