import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

    static renderForecastsTable(forecasts) {
        return (                              
            <div>
                <header className="masthead" style={{ backgroundImage: "url('/home-bg.jpg')" }}>
                    <div className="container position-relative px-4 px-lg-5">
                        <div className="row gx-4 gx-lg-5 justify-content-center">
                            <div className="col-md-10 col-lg-8 col-xl-7">
                                <div className="site-heading">
                                    <h1>BlogMaster</h1>
                                    <span className="subheading">A Dynamic Blog</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </header>

                <div className="container px-4 px-lg-5">
                    <div className="row gx-4 gx-lg-5 justify-content-center">
                        <div className="col-md-10 col-lg-8 col-xl-7">
                            {forecasts.map(forecast =>

                                <div className="post-preview" key={forecast.articleId}>
                                    <a href={`~/Blog/Post/${forecast.articleId}`}>
                                        <h2 className="post-title">{forecast.header}</h2>
                                        <h3 className="post-subtitle">{forecast.subHeader}</h3>
                                    </a>
                                    <p className="post-meta">
                                        Posted by
                                        <a href={`~/Blog/About/${forecast.username}`}>{forecast.username}</a>
                                        {forecast.creationDate}
                                    </p>
                                </div>
                            )}
                            <hr className="my-4" />
                            <div className="d-flex justify-content-end mb-4">
                                <a className="btn btn-primary text-uppercase" href="#!">Older Posts →</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        {/*<h1 id="tabelLabel" >Weather forecast</h1>*/}
        {/*<p>This component demonstrates fetching data from the server.</p>*/}
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
      const response = await fetch('https://localhost:7296/api/Article/GetArticleInformationForHomePage');
      debugger;
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
