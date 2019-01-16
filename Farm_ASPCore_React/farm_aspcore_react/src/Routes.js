import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import TableView from "./components/TableView";

class Routes extends Component {
  render() {
    return (
      <Switch>
        <Route
          exact
          path="/"
          render={props => (
            <TableView
              {...props}
              data={this.props.data}
              currentlyLoaded={this.props.currentlyLoaded}
              acquireMachine={this.props.acquireMachine}
              releaseMachine={this.props.releaseMachine}
              splitCultivation={this.props.splitCultivation}
              addWorker={this.props.addWorker}
              editWorker={this.props.editWorker}
              summary={this.props.summary}
              delete={this.props.delete}
              saveState={this.props.saveState}
              restoreState={this.props.restoreState}
              handleSow={this.props.handleSow}
              handleHarvest={this.props.handleHarvest}
              bonus={this.props.bonus}
            />
          )}
        />
      </Switch>
    );
  }
}

export default Routes;
