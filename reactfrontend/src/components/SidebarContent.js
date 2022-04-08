import { AddIcon, CalendarIcon, EditIcon, ViewIcon } from "@chakra-ui/icons";
import {
  Box,
  CloseButton,
  Flex,
  Text,
  Center,
  Divider,
} from "@chakra-ui/react";
import React from "react";
import NavItem from "./NavItem";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
const SidebarContent = ({ onClose, selectedDate, setSelectedDate }) => {
  return (
    <>
      <Box boxShadow="dark-lg" w={{ base: "full" }} pos="fixed" h="full">
        <Flex
          h="20"
          alignItems="center"
          mx="8"
          justifyContent="space-between"
          flexWrap="wrap"
        >
          <Text fontSize="2xl" fontFamily="monospace" fontWeight="bold">
            Logo
          </Text>
          <CloseButton
            display={{ base: "flex", md: "none" }}
            onClick={onClose}
          />
          <DatePicker
            selected={selectedDate}
            onChange={(date) => {
              setSelectedDate(date);
            }}
          />
        </Flex>

        <NavItem name="Home" address="/home" icon={ViewIcon}>
          To Do
        </NavItem>
        <NavItem name="To Do" address="/todos" icon={CalendarIcon}>
          To Do
        </NavItem>
        <NavItem name="Schedule" address="/schedule" icon={EditIcon}>
          Schedule
        </NavItem>
        <NavItem name="Finances" address="/finances" icon={AddIcon}>
          Finances
        </NavItem>
      </Box>
    </>
  );
};

export default SidebarContent;
