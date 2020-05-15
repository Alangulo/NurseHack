import React from 'react';
import { Switch, Route } from 'react-router-dom';

import Patients from './Patients';
import Resume from './LandingPage';
import LandingPage from './LandingPage';

const Main = () => (
    <Switch>
        <Route exact path="/" component={LandingPage}/>
        <Route path="/Patients" component={Patients}/>
        <Route path="/resume" component={Resume}/>
    </Switch>
)

export default Main;