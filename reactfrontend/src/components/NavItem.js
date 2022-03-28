import { CalendarIcon } from "@chakra-ui/icons";
import { Link as ChakraLink, Flex, Icon } from "@chakra-ui/react";

import React from "react";
import { Link } from "react-router-dom";
const NavItem = ({ address, icon, name }) => {
  return (
    <>
      <ChakraLink as={Link} to={address}>
        <Flex
          align="center"
          justifyContent="space-between"
          p="4"
          mx="4"
          borderRadius="lg"
          role="group"
          cursor="pointer"
          _hover={{
            bg: "cyan.400",
            color: "white",
          }}
        >
          {name}
          <Icon
            mr="4"
            fontSize="16"
            _groupHover={{ color: "white" }}
            as={icon}
          ></Icon>
        </Flex>
      </ChakraLink>
    </>
  );
};

export default NavItem;
