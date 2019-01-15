import React, { Component } from "react";
import "./FarmTable.css";
import TableRow from "./TableRow";
import translate from "../services/TranslationService";
import { Table } from "react-bootstrap";

class FarmTable extends Component {
  renderHeaders() {
    const heads = [];
    if (this.props.data.length <= 0) return;
    const keys = Object.keys(this.props.data[0]);
    keys.forEach(key => {
      heads.push(
        <th key={keys.indexOf(key)} style={{ textAlign: "center" }}>
          {translate(key)}
        </th>
      );
    });
    let addidtionalHeaders;
    switch (this.props.currentlyLoaded) {
      case "Worker":
        addidtionalHeaders = 2;
        break;
      case "Stable":
        addidtionalHeaders = 1;
        break;
      case "Cultivation":
        addidtionalHeaders = 1;
        break;
      case "Machine":
        addidtionalHeaders = 1;
        break;
      default:
        console.error("Data source unrecognized", this.props.currentlyLoaded);
        break;
    }
    for (let i = 0; i < addidtionalHeaders; i++)
      heads.push(<th key={keys.length + i} />);
    return heads;
  }

  render() {
    return (
      <div className="table">
        <Table>
          <thead>
            <tr>{this.renderHeaders()}</tr>
          </thead>
          <tbody>
            {this.props.data.map(rowData => (
              <TableRow
                key={rowData.id}
                rowData={rowData}
                currentlyLoaded={this.props.currentlyLoaded}
                releaseMachine={this.props.releaseMachine}
              />
            ))}
          </tbody>
        </Table>
      </div>
    );
  }
}

export default FarmTable;
