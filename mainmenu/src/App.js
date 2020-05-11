import React, { Component } from 'react';
import './App.css';
import {Layout, Header, Drawer, Navigation, Content} from 'react-mdl';
class App extends Component {
    render() {
      return (
        <div className="demo-big-content">
    <Layout>
        <Header title="Hospital Resources" scroll>
            <Navigation>
                <a href="#">Profile</a>
            </Navigation>
        </Header>
        <Drawer title="Navigation">
            <Navigation>
            <a href="/">Patients</a>
                <a href="/">Messages</a>
                <a href="/">Data Dashboard</a>
                <a href="#">Supplies</a>
                <a href="#">Log Out</a>
            </Navigation>
        </Drawer>
        <Content>
            <div className="page-content" />
        </Content>
    </Layout>
</div>
      )
    }
  }

export default App; 