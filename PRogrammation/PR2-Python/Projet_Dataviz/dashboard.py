"""
Generate the dashboard
"""
# imports
import textwrap
import json
import urllib.request
import pandas as pd

import plotly_express as px

import dash
import dash_bootstrap_components as dbc
import dash_core_components as dcc
import dash_html_components as html
from dash.dependencies import Input, Output, State

# Global variables

# the style arguments for the sidebar.
SIDEBAR_STYLE = {
    'float': 'left',
    'top': 0,
    'left': 0,
    'bottom': 0,
    'width': '30%',
    'padding': '20px 10px',
    'background-color': '#f8f9fa'
}
# the style arguments for the main content page.
CONTENT_STYLE = {
    'margin-left': '0%',
    'margin-right': '0%',
    'top': 0,
    'width': '100%',
    'padding': '20px 10px'
}

# the style arguments for the page text.
TEXT_STYLE = {
    'textAlign': 'center',
    'color': '#191970'
}
# parameters
DATAS = dict()
AGES = dict()
DEPARTMENTS = []
DATES = []
# the dataframe
DATAFRAME = pd.DataFrame()
# the running dashboard
APP = dash.Dash(external_stylesheets=[dbc.themes.BOOTSTRAP])

def create_controls():
    """
    create the control panel
    """
    controls = dbc.FormGroup(
        [
            html.P('Donnees', style={
                'textAlign': 'center'
            }),
            dbc.Card([dbc.RadioItems(
                id='data',
                options=[ {'label' : DATAS[key], 'value':key}
                            for key in DATAS], # possible values
                value='tests',
                style={
                    'margin': 'auto'
                }
            )]),
            html.Br(),
            html.P('Tranches d\'age', style={
                'textAlign': 'center'
            }),
            dbc.Card([dbc.RadioItems(
                    id='age_category', # id
                    options=[ {'label' : AGES[key], 'value':key}
                            for key in AGES], # possible values
                    value=0,  # default value
                    style={
                    'margin': 'auto'
                }
            )]),
            html.Br(),
            html.P('Departements', style={
                'textAlign': 'center'
            }),
            dcc.Dropdown(
                id='department',
                options=[ {'label' : dep, 'value':dep} for dep in DEPARTMENTS], # possible values
                value=DEPARTMENTS,  # default value
                multi=True
            ),
            html.Br(),
            html.P('Date (carte)', style={
                'textAlign': 'center'
            }),
            dcc.Slider(
                id='date',
                min=0,
                max=len(DATES)-1,
                marks= {    index:date[5:]
                            for date,index in zip(DATES,range(len(DATES)))
                            if (
                                date == DATES[0] or
                                date == DATES[-1] or
                                date[-2:] == '01'
                            )
                        },
                value=0,
                included=False
            ),
            html.Br(),
            dbc.Button(
                id='submit_button',
                n_clicks=0,
                children='Submit',
                color='primary',
                block=True
            ),
        ]
    )

    return controls

def create_sidebar(controls):
    """
    Assemble the controls in an HTML division to form the sidebar

    args :
        controls : the controls needed to modify the graphs
    """
    sidebar = html.Div(
        [
            html.H2('Parametres', style=TEXT_STYLE),
            html.Hr(),
            controls
        ],
        style=SIDEBAR_STYLE,
    )
    return sidebar

def create_rows():
    """
    create the rows where the graphs will be presented

    returns:
        the list of the rows
    """
    first_row = dbc.Row([dbc.Col(dcc.Graph(id='histogram'), md=12)])
    second_row = dbc.Row([dbc.Col(dcc.Graph(id='map'), md=12)])
    return [first_row, second_row]

def create_content(rows):
    """
    Assemble the rows to create the content of the dashboard

    args :
        rows : the rows of the content

    return :
        the content of the dashboard
    """
    # the content itself
    content = html.Div(
        [
            html.H2('', style=TEXT_STYLE),
            html.Hr()
        ] + rows,
        style=CONTENT_STYLE
    )
    return content

def create_histogram(dataframe, data_value, age_category_value, department_value):
    """
    create the histogram using the given options and data

    args :
        dataframe : the used dataframe
        data_value : the value of the data to be represented
        age_category : the age category of the data to be represented
        department_value : the departments of the data to be represented

    return :
        the histogram
    """
    if age_category_value == 0:
        histogram_title = str(DATAS[data_value] + " pour les personnes de tout age dans les departements selectionnes")
    else:
        histogram_title = str(  DATAS[data_value] + " pour les personnes de " + str(AGES[age_category_value]) + " ans, dans les departements selectionnes")
    histogram_title = '<br>'.join(textwrap.wrap(histogram_title, width=110))

    filtered_df = dataframe.query( "age_category == " +
                            str(age_category_value) +
                            " and department in " +
                            str(department_value)
                            )

    fig = px.histogram( data_frame=filtered_df,
                        x="day",
                        y=data_value,
                        title=histogram_title,
                        nbins=len(DATES)
                        )
    return fig

def create_map(dataframe,data_value, age_category_value, date_value): # Not functional
    """
    create the map using the given options and data

    args :
        dataframe : the used dataframe
        data_value : the value of the data to be represented
        age_category : the age category of the data to be represented
        date_value : the date of the data to be represented

    return :
        the map
    """
    departments = None
    url_geojson = "https://france-geojson.gregoiredavid.fr/repo/departements.geojson"
    with urllib.request.urlopen(url_geojson) as response:
        departments = json.load(response)

    filtered_df = dataframe.query( "age_category == " +
                            str(age_category_value) +
                            " and day == " +
                            str(date_value)
                        )

    fig = px.choropleth(filtered_df,
                        geojson=departments, locations='department', color=data_value,
                        color_continuous_scale="icefire",
                        range_color=(0, dataframe[data_value].max()),
                        scope="europe",
                        labels={data_value:DATAS[data_value]}
                    )
    fig.update_layout(margin={"r":0,"t":0,"l":0,"b":0})
    return fig

def generate_dashboard(dataframe):
    """
    Produces the dashboard from the processed_data.csv file
    """

    global DATAFRAME, DATAS, AGES, DEPARTMENTS, DATES, APP

    DATAFRAME = dataframe

    DATAS = {'tests':'Nombre de tests', 'positive_tests':'Nombre de tests positifs'}

    AGES = {value : (str(str(value-9)+'-'+str(value)))
            for value in dataframe.age_category.unique()
            if (9 <= value < 90)
            }
    AGES[90]="90+"
    AGES[0]="Tout age"

    DEPARTMENTS = dataframe["department"].unique()

    DATES = dataframe["day"].unique()

    controls = create_controls()
    sidebar = create_sidebar(controls)

    rows = create_rows()
    content = create_content(rows)

    APP.layout = html.Div([sidebar, content], style={'display': 'inline-block', 'width': '100%'})
    APP.run_server(debug=True)

# histogram update decorator
@APP.callback(
        Output('histogram', 'figure'),
        [Input('submit_button', 'n_clicks')],
        [State('data', 'value'), State('age_category', 'value'), State('department', 'value')])
def update_histogram(n_clicks, data_value, age_category_value, department_value):
    """
    Updates the histogram

    args :
        n_clicks number of clicks
        data_value ... department_value the entered values in the parameters division
    """
    fig = create_histogram(DATAFRAME, data_value, age_category_value, department_value)
    return fig

# map update decorator
@APP.callback(
        Output('map', 'figure'),
        [Input('submit_button', 'n_clicks')],
        [State('data', 'value'), State('age_category', 'value'), State('date', 'value')])
def update_map(n_clicks, data_value, age_category_value, date_value):
    """
    Updates the map
    """
    # fig = create_map(dataframe, data_value, age_category_value, date_value) #Dysfonctionnel
    fig = {
        'data': [{
            'x': [1, 2, 3],
            'y': [3, 4, 5]
        }]
    }
    return fig
