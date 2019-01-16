import React, { Component } from "react";
import "./App.css";
import Routes from "./Routes";
import FarmNavbar from "./components/FarmNavbar";
import {
  NotificationManager,
  NotificationContainer
} from "react-notifications";
import "react-notifications/lib/notifications.css";

class App extends Component {
  state = {
    data: [],
    currentlyLoaded: "Worker",
    summary: []
  };

  componentDidMount() {
    this.fetchNewData("Worker");
    localStorage.setItem("Machine", "[]");
  }

  fetchNewData = param => {
    if (this.state.currentlyLoaded === "Machine") {
      localStorage.setItem("Machine", JSON.stringify(this.state.data));
    }
    this.setState({ currentlyLoaded: param });
    if (param === "Machine") {
      const machines = localStorage.getItem("Machine");
      this.setState({ data: JSON.parse(machines) });
      return;
    }
    fetch("http://localhost:62573/api/" + param)
      .then(response => response.json())
      .then(data => {
        if (param === "Worker" || param === "Machine")
          data.forEach(worker => {
            delete worker["farmId"];
            delete worker["farm"];
            delete worker["startOfContract"];
            delete worker["endOfContract"];
            delete worker["usdPerHour"];
            delete worker["hoursPerDay"];
            delete worker["daysOfWork"];
          });
        this.setState({ data });
      });
  };

  acquireMachine = () => {
    fetch("http://localhost:62573/api/Machine")
      .then(response => response.json())
      .then(data => {
        if (data["id"]) {
          const currData = this.state.data;
          currData.push(data);
          this.setState({ data: currData });
        } else {
          this.createNotification("error", data["message"]);
        }
      });
  };

  releaseMachine = id => {
    let filterState = true;
    let message;
    fetch("http://localhost:62573/api/Machine/" + id)
      .then(response => response.json())
      .then(data => {
        if (data["message"]) {
          filterState = false;
          message = data["message"];
          return;
        }
      });
    if (filterState) {
      let data = this.state.data;
      data = data.filter(element => element.id !== id);
      this.setState({ data });
    } else {
      this.createNotification("error", message);
    }
  };

  fetchSummary = () => {
    fetch("http://localhost:62573/api/Summary")
      .then(response => response.json())
      .then(data => {
        this.setState({ summary: data });
        console.log(data);
      });
  };

  splitCultivation = (ratio, id) => {
    fetch("http://localhost:62573/api/Cultivation/Split/" + ratio + "/" + id)
      .then(response => response.json())
      .then(data => {
        this.setState({ data });
        console.log(data);
      });
  };

  addWorker = worker => {
    fetch("http://localhost:62573/api/Worker" + worker["kind"], {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify(worker)
    });
    this.fetchNewData("Worker");
  };

  delete = id => {
    fetch(
      "http://localhost:62573/api/" + this.state.currentlyLoaded + "/" + id,
      {
        method: "delete"
      }
    );
    this.fetchNewData(this.state.currentlyLoaded);
  };

  saveState = () => {
    console.log(this.state.summary[0]);
    fetch("http://localhost:62573/api/Summary", {
      method: "POST",
      body: JSON.stringify(this.state.summary[0])
    });
  };

  createNotification = (type, data) => {
    switch (type) {
      case "info":
        return NotificationManager.info(data);
      case "success":
        return NotificationManager.success(data);
      case "warning":
        return NotificationManager.warning(data);
      case "error":
        return NotificationManager.error(data);
      default:
        return NotificationManager.error("Invalid notification type specified");
    }
  };

  render() {
    this.fetchSummary();
    return (
      <div className="App">
        <FarmNavbar
          fetchNewData={this.fetchNewData}
          fetchSummary={this.fetchSummary}
        />
        <NotificationContainer />
        <Routes
          data={this.state.data}
          currentlyLoaded={this.state.currentlyLoaded}
          acquireMachine={this.acquireMachine}
          releaseMachine={this.releaseMachine}
          splitCultivation={this.splitCultivation}
          editWorker={this.editWorker}
          summary={this.state.summary[0]}
          delete={this.delete}
          saveState={this.saveState}
        />
      </div>
    );
  }
}

export default App;
