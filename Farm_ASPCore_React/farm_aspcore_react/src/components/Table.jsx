import React, { Component } from "react";
import "./Table.css";
import TableRow from "./TableRow";

class Table extends Component {
  translate(key) {
    let translation = "";
    switch (key) {
      default:
        translation = "klucz";
        break;
    }
    return translation;
  }

  renderHeaders() {
    const heads = [];
    if (this.props.data.length <= 0) return;
    const keys = Object.keys(this.props.data[0]);
    keys.forEach(key => {
      heads.push(
        <th key={keys.indexOf(key)} style={{ textAlign: "center" }}>
          translate(key)
        </th>
      );
    });
    return heads;
  }

  render() {
    return (
      <div className="table">
        {
          <table>
            <thead>
              <tr>{this.renderHeaders()}</tr>
            </thead>
            <tbody>
              {this.props.data.map(rowData => (
                <TableRow key={rowData.id} rowData={rowData} />
              ))}
            </tbody>
          </table>
        }
      </div>
    );
  }
}

export default Table;
