import React, { Component } from "react";
import FarmTable from "./FarmTable";

class TableView extends Component {
  render() {
    return (
      <div className="table-view">
        <FarmTable data={this.props.data} />
      </div>
    );
  }
}

export default TableView;
