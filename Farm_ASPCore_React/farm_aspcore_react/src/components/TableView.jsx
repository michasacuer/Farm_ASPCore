import React, { Component } from "react";
import Table from "./Table";

class TableView extends Component {
  state = {
    data: []
  };

  componentDidMount() {
    fetch("http://localhost:62573/api/Farm")
      .then(response => response.json())
      .then(data => this.setState({ data }));
  }

  render() {
    return <Table data={this.state.data} />;
  }
}

export default TableView;
