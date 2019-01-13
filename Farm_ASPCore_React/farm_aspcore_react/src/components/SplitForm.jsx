import React, { Component } from "react";
import {
  Modal,
  Button,
  Form,
  FormGroup,
  FormControl,
  Col,
  Row
} from "react-bootstrap";
import Slider from "rc-slider";
import "rc-slider/assets/index.css";
import "./SplitForm.css";

class SplitForm extends Component {
  state = { ratio: 0.5, firstCultivationSize: 0, secondCultivationSize: 0 };

  handleSubmit = e => {
    console.log(this.state.fieldsData);
    this.props.setSplitFormVisible(false);
    e.preventDefault();
  };

  handleChange = value => {
    this.setState({ ratio: value });
  };

  render() {
    return (
      <Modal show={this.props.visible}>
        <Form onSubmit={this.handleSubmit}>
          <Modal.Header>
            <Modal.Title>PODZIEL</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <FormGroup controlId="1">
              <Row>
                <Col sm={2}>
                  <FormControl
                    value={this.state.firstCultivationSize}
                    defaultValue={this.state.firstCultivationSize}
                  />
                </Col>
                <Col sm={8} style={{ display: "flex !important" }}>
                  <Slider
                    min={0.1}
                    max={0.9}
                    dots
                    defaultValue={0.5}
                    step={0.1}
                    onChange={this.handleChange}
                  />
                </Col>
                <Col sm={2}>
                  <FormControl value={this.state.secondCultivationSize} />
                </Col>
              </Row>
            </FormGroup>
          </Modal.Body>
          <Modal.Footer>
            <Button type="submit" bsStyle="success">
              ZATWIERDŹ
            </Button>
          </Modal.Footer>
        </Form>
      </Modal>
    );
  }
}

export default SplitForm;
