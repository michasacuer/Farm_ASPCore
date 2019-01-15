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
    currentlyLoaded: "Worker"
  };

  componentDidMount() {
    this.fetchNewData("Worker");
  }

  fetchNewData = param => {
    this.setState({ currentlyLoaded: param });
    if (param === "Machine") {
      this.setState({ data: [] });
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
            delete worker["baseSalary"];
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
        console.log(data);
        if (data["message"]) {
          filterState = false;
          message = data["message"];
          return;
        }
      });
    if (filterState) {
      console.log(filterState);
      let data = this.state.data;
      data = data.filter(element => element.id !== id);
      this.setState({ data });
    } else {
      this.createNotification("error", message);
    }
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
    return (
      <div className="App">
        <FarmNavbar fetchNewData={this.fetchNewData} />
        <NotificationContainer />
        <Routes
          data={this.state.data}
          currentlyLoaded={this.state.currentlyLoaded}
          acquireMachine={this.acquireMachine}
          releaseMachine={this.releaseMachine}
        />
      </div>
    );
  }
}

export default App;
