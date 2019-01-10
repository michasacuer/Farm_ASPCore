import React, { Component } from "react";
import FarmTable from "./FarmTable";

class TableView extends Component {
  render() {
    return <FarmTable data={this.props.data} />;
  }
}

export default TableView;
