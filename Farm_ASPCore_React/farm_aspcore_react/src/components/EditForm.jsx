import React, { Component } from "react";
import { Modal, FormGroup, Form, FormControl } from "react-bootstrap";

class EditForm extends Component {
  state = { fieldsData: {} };
  render() {
    return (
      <Modal show={this.props.visible}>
        <Modal.Header>
          <Modal.Title>EDYTUJ</Modal.Title>
        </Modal.Header>
        <Modal.Body>{}</Modal.Body>
      </Modal>
    );
  }
}

export default EditForm;
