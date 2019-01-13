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

  componentDidMount() {
    this.setState({
      firstCultivationSize: this.state.ratio * this.props.acreage,
      secondCultivationSize: (1 - this.state.ratio) * this.props.acreage
    });
  }

  handleSubmit = e => {
    console.log(this.state.ratio);
    this.props.setSplitFormVisible(false);
    e.preventDefault();
  };

  handleChange = value => {
    this.setState({
      ratio: value,
      firstCultivationSize: (this.props.acreage * value).toPrecision(3),
      secondCultivationSize: (this.props.acreage * (1 - value)).toPrecision(3)
    });
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
                    readOnly
                  />
                </Col>
                <Col sm={8} style={{ display: "flex !important" }}>
                  <Slider
                    min={0}
                    max={1}
                    marks={{
                      0.1: "",
                      0.2: "",
                      0.3: "",
                      0.4: "",
                      0.5: "",
                      0.6: "",
                      0.7: "",
                      0.8: "",
                      0.9: ""
                    }}
                    dots={false}
                    defaultValue={0.5}
                    step={null}
                    onChange={this.handleChange}
                    trackStyle={{ backgroundColor: "#5cb85c", height: 8 }}
                    railStyle={{ backgroundColor: "#00BFFF", height: 8 }}
                    handleStyle={{ height: 18, width: 18 }}
                    dotStyle={{ display: "none" }}
                  />
                </Col>
                <Col sm={2}>
                  <FormControl
                    value={this.state.secondCultivationSize}
                    readOnly
                  />
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
