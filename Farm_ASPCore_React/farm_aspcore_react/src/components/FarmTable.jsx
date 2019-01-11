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
    return heads;
  }

  render() {
    return (
      <div className="table">
        <Table>
          <thead>
            <tr>
              {this.renderHeaders()}
              <th />
              <th />
            </tr>
          </thead>
          <tbody>
            {this.props.data.map(rowData => (
              <TableRow key={rowData.id} rowData={rowData} />
            ))}
          </tbody>
        </Table>
      </div>
    );
  }
}

export default FarmTable;
