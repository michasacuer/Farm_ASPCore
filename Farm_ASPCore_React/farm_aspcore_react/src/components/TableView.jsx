import React, { Component } from "react";
import FarmTable from "./FarmTable";
import "./TableView.css";

class TableView extends Component {
  render() {
    return (
      <div className="table-view">
        <FarmTable
          data={this.props.data}
          currentlyLoaded={this.props.currentlyLoaded}
        />
      </div>
    );
  }
}

export default TableView;
