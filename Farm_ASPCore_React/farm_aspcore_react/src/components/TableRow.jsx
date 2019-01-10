import React, { Component } from "react";
import "./TableRow.css";

class TableRow extends Component {
  state = {
    showDeleteForm: false,
    showEditForm: false
  };

  renderRow() {
    const { rowData } = this.props;
    const rowKeys = Object.keys(rowData);
    const cells = [];
    rowKeys.forEach(key => {
      cells.push(<td key={rowKeys.indexOf(key)}>{rowData[key]}</td>);
    });
    return cells;
  }

  render() {
    return (
      <tr>
        {this.renderRow()}
        <td>
          {/* eslint-disable-next-line */}
          <a href="#">EDYTUJ</a>
        </td>
        {/* FORM */}
        <td>
          {/* eslint-disable-next-line */}
          <a href="#">USUŃ</a>
        </td>
        {/* FORM */}
      </tr>
    );
  }
}

export default TableRow;
