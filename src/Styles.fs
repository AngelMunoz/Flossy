module Styles

open Lit

let floDesktop =
    css
        $"""
        article {{
            display: flex;
            flex-direction: column;
            height: 100vh;
            overflow: hidden;
        }}

        footer {{
            position: absolute;
            bottom: 0;
            z-index: 2;
            height: 45px;
        }}

        .win footer {{
            left: 0;
            right: 0;
        }}

        .osx footer {{
            left: 35%%
            right: 35%%
        }}

        aside {{
            position: absolute;
            bottom: 45px;
            top: 0;
            right: 0;
            z-index: 2;
            display: none;
        }}

        aside.show {{
            display: flex;
        }}

        section {{
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            z-index: 0;
        }}
    """

let floTaskbar =
    css
        $"""
        nav {{
            margin: 0 1em;
            display: flex;
            justify-content: center;
        }}
        ul {{
            display: flex;
            justify-content: space-evenly;
        }}
    """
