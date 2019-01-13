import React, { Component } from "react";
import {
  Modal,
  Button,
  Form,
  FormGroup,
  ControlLabel,
  FormControl
} from "react-bootstrap";
import Slider from "rc-slider";
import "rc-slider/assets/index.css";

class SplitForm extends Component {
  state = { fieldsData: {} };

  handleSubmit = e => {
    console.log(this.state.fieldsData);
    this.props.setSplitFormVisible(false);
    e.preventDefault();
  };

  render() {
    return (
      <Modal show={this.props.visible}>
        <Modal.Header>
          <Modal.Title>PODZIEL</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form onSubmit={this.handleSubmit}>
            <FormGroup controlId="1">
              {/* dać to w jednej linii */}
              <ControlLabel>Ratio</ControlLabel>
              <FormControl />
              <Slider />
              <FormControl />
            </FormGroup>
            <Button type="submit">ZATWIERDŹ</Button>
          </Form>
        </Modal.Body>
      </Modal>
    );
  }
}

export default SplitForm;
