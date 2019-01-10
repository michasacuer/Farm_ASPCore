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
      .then(data => this.setState({ data }));
  }

  fetchNewData = param => {
    fetch("http://localhost:62573/api/" + param)
      .then(response => response.json())
      .then(data => this.setState({ data, currentlyLoaded: param }));
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
