import React, { Component } from "react";
import { Button } from "react-bootstrap";
import FarmTable from "./FarmTable";
import "./TableView.css";

class TableView extends Component {
  render() {
    return (
      <div className="table-view">
        <FarmTable
          data={this.props.data}
          currentlyLoaded={this.props.currentlyLoaded}
          releaseMachine={this.props.releaseMachine}
        />
        {this.props.currentlyLoaded === "Machine" ? (
          <Button bsStyle="primary" onClick={this.props.acquireMachine}>
            Zajmij maszynę
          </Button>
        ) : null}
      </div>
    );
  }
}

export default TableView;
