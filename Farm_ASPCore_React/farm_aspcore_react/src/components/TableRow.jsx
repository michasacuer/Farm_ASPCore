import React, { Component } from "react";
import "./TableRow.css";

class TableRow extends Component {
  state = {
    showDeleteForm: false,
    showEditForm: false
  };

  renderRows() {}

  render() {
    return (
      <tr>
        {this.renderRows}
        <a href="#">EDYTUJ</a>
        {/* FORM */}
        <a href="#">USUŃ TO</a>
        {/* FORM */}
      </tr>
    );
  }
}

export default TableRow;
