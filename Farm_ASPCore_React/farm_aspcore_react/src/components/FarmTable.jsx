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
    let additionalHeaders;
    switch (this.props.currentlyLoaded) {
      case "Worker":
        additionalHeaders = 3;
        break;
      case "Stable":
        additionalHeaders = 0;
        break;
      case "Cultivation":
        additionalHeaders = 3;
        break;
      case "Machine":
        additionalHeaders = 1;
        break;
      case "Summary/list":
        additionalHeaders = 1;
        break;
      default:
        additionalHeaders = 0;
        break;
    }
    for (let i = 0; i < additionalHeaders; i++)
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
                splitCultivation={this.props.splitCultivation}
                editWorker={this.props.editWorker}
                delete={this.props.delete}
                restoreState={this.props.restoreState}
                handleSow={this.props.handleSow}
                handleHarvest={this.props.handleHarvest}
                bonus={this.props.bonus}
              />
            ))}
          </tbody>
        </Table>
      </div>
    );
  }
}

export default FarmTable;
