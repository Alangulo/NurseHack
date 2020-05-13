import React from 'react';
import { Switch, Route } from 'react-router-dom';

import Patients from './Patients';
import Resume from './resume';

const Main = () => (
    <Switch>
        <Route path="/Patients" component={Patients}/>
        <Route path="/resume" component={Resume}/>
    </Switch>
)

export default Main;