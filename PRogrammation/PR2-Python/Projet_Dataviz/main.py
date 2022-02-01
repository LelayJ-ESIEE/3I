"""
This module generates a dashboard presenting the main informations
about CoViD-19 infection in France
"""

# imports

import urllib.request
import pandas as pd

import dashboard as db

#functions

def download_data():
    """
    Download the raw_data.csv file from the source

    Actual Source :
    https://www.data.gouv.fr/fr/datasets/donnees-relatives-aux-resultats-des-tests-virologiques-covid-19/#_
                    Ressources > Fichier principal > Taux de positivité - quotidien - département
    Stable URL :    https://www.data.gouv.fr/fr/datasets/r/406c6a23-e283-4300-9484-54e78c8ae675
    """
    url_data = 'https://www.data.gouv.fr/fr/datasets/r/406c6a23-e283-4300-9484-54e78c8ae675'
    urllib.request.urlretrieve(url_data, './raw_data.csv')

def process_data(export_dataframe : bool = False):
    """
    Process the raw_data.csv file to get the processed_data.csv file as follow :
        Rename columns to explicits names

    args :
        export_dataframe :  boolean, determines if the dataframe is only returned or if it is
                            exported to csv, in order to verify if data are not altered

    return :
        the processed_dataframe
    """
    # read raw_data.csv
    dataframe = pd.read_csv("./raw_data.csv", sep=";", low_memory=False)
    # cast the data['dep'] serie to a serie which dtype == str,
    # else dtype == object and some codes are interpreted as int for unknown reason
    dataframe['dep'] = dataframe['dep'].astype(str,False)
    # rename columns to explicits names in place
    dataframe.rename(columns={   "dep":"department",
                                "jour":"day",
                                "P":"positive_tests",
                                "T":"tests",
                                "cl_age90":"age_category",
                                "pop":"population"},
                                inplace=True)
    # exports the dataframe to csv file processed_data.csv si demande en argument
    if export_dataframe:
        dataframe.to_csv("./processed_data.csv", sep=";", index=False)
    return dataframe

# main

if __name__ == "__main__":
    download_data()
    dataf = process_data(False)
    db.generate_dashboard(dataf)
