#!/bin/bash

docker build -t simple-todo-backend .
docker tag simple-todo-backend tombreplacer/simple-todo-backend
docker push tombreplacer/simple-todo-backend
