import React, { Component } from "react";
import "./App.css";
import Routes from "./Routes";
import FarmNavbar from "./components/FarmNavbar";

class App extends Component {
  state = {
    data: [],
    currentlyLoaded: "Worker"
  };

  componentDidMount() {
    fetch("http://localhost:62573/api/Worker")
      .then(response => response.json())
      .then(data => {
        data.forEach(worker => {
          delete worker["salary"];
          delete worker["farmId"];
          delete worker["farm"];
          delete worker["startOfContract"];
          delete worker["endOfContract"];
          delete worker["usdPerHour"];
          delete worker["hoursPerDay"];
          delete worker["daysOfWork"];
          delete worker["baseSalary"];
          delete worker["kind"];
        });
        this.setState({ data });
      });
  }

  fetchNewData = param => {
    fetch("http://localhost:62573/api/" + param)
      .then(response => response.json())
      .then(data => {
        if ((param = "Worker"))
          data.forEach(worker => {
            delete worker["salary"];
            delete worker["farmId"];
            delete worker["farm"];
            delete worker["startOfContract"];
            delete worker["endOfContract"];
            delete worker["usdPerHour"];
            delete worker["hoursPerDay"];
            delete worker["daysOfWork"];
            delete worker["baseSalary"];
            delete worker["kind"];
          });
        this.setState({ data, currentlyLoaded: param });
      });
  };

  render() {
    return (
      <div className="App">
        <FarmNavbar fetchNewData={this.fetchNewData} />
        <Routes data={this.state.data} />
      </div>
    );
  }
}

export default App;
