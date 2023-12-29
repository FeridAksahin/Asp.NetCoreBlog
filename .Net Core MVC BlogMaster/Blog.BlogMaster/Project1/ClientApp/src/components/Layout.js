import React, { Component } from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import { Helmet } from 'react-helmet';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div>
                <Helmet>
                    <meta charSet="utf-8" />
                    <meta
                        name="viewport"
                        content="width=device-width, initial-scale=1, shrink-to-fit=no"
                    />
                    <meta name="description" content="" />
                    <meta name="author" content="" />
                    <title>BlogMaster</title>
                    <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
                    <script
                        src="https://use.fontawesome.com/releases/v6.3.0/js/all.js"
                        crossOrigin="anonymous"
                    ></script>
                    <link
                        href="https://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic"
                        rel="stylesheet"
                        type="text/css"
                    />
                    <link
                        href="https://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800"
                        rel="stylesheet"
                        type="text/css"
                    /> 
                </Helmet>
                <NavMenu />
                <Container>{this.props.children}</Container>
            </div>
        );
    }
}
